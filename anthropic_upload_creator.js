const fs = require('fs');
const path = require('path');

function copyFilesRecursively(src, dest) {
    if (!fs.existsSync(dest)) {
        fs.mkdirSync(dest, { recursive: true });
    }

    const items = fs.readdirSync(src);

    items.forEach(item => {
        const srcPath = path.join(src, item);
        const destPath = path.join(dest, item);

        if (fs.lstatSync(srcPath).isDirectory()) {
            if (!/^(obj|bin|out|\.vs)$/.test(item)) {
                copyFilesRecursively(srcPath, dest);
            }
        } else if (/\.(cs|xaml|csproj|sln|md)$/.test(item)) {
            if (fs.existsSync(destPath)) {
                throw new Error(`File ${destPath} already exists`);
            }
            fs.copyFileSync(srcPath, path.join(dest, item));
        }
    });
}

// Example usage
const sourceDirectory = './'; // Replace with your source directory
const destinationDirectory = './out';

// Delete 'out' directory if it exists
if (fs.existsSync(destinationDirectory)) {
    fs.rmSync(destinationDirectory, { recursive: true, force: true });
}

// Recreate 'out' directory
fs.mkdirSync(destinationDirectory, { recursive: true });

copyFilesRecursively(sourceDirectory, destinationDirectory);
