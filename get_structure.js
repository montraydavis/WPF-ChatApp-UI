const fs = require('fs');
const path = require('path');

function generateStructureReport(src, indent = '', report = []) {
    const items = fs.readdirSync(src);

    items.forEach(item => {
        const srcPath = path.join(src, item);
        const isDirectory = fs.lstatSync(srcPath).isDirectory();

        if (isDirectory && /^(bin|obj|\.vs|out)$/.test(item)) {
            return;
        }

        if (!isDirectory && !/\.(xaml|cs|csproj|sln|md|json)$/.test(item)) {
            return;
        }

        report.push(`${indent}${isDirectory ? '📁' : '📄'} ${item}`);

        if (isDirectory) {
            generateStructureReport(srcPath, indent + '  ', report);
        }
    });

    return report;
}

// Example usage
const sourceDirectory = './'; // Replace with your source directory
const report = generateStructureReport(sourceDirectory);
const reportPath = path.join('out', 'structure.md');

if (!fs.existsSync('out')) {
    fs.mkdirSync('out', { recursive: true });
}

fs.writeFileSync(reportPath, report.join('\n'), 'utf8');
