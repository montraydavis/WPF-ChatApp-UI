# QNAGen Project Documentation

## Project Overview

QNAGen is a WPF application designed to generate Questions and Answers using a Language Learning Model (LLM). The project is currently in the design stage and uses .NET 7.0 for Windows.

## Project Structure

### Views
1. **MainWindow**: The main application window that hosts other views and controls.
2. **QNAView**: A view for the QNA generation functionality.
3. **SettingsView**: A view for application settings.

### Controls
1. **AppTopBar**: A custom control for the application's top navigation bar.
2. **AppSideBar**: A custom control for the application's side navigation bar.
3. **TypingIndicator**: A custom control that displays an animated typing indicator.

### Converters
1. **BoolToAlignmentConverter**: Converts a boolean value to a HorizontalAlignment.
2. **BoolToColorConverter**: Converts a boolean value to a SolidColorBrush.
3. **BoolToLabelConverter**: Converts a boolean value to a string label ("User" or "Assistant").
4. **BrightenColorConverter**: Brightens a given color.
5. **DarkenColorConverter**: Darkens a given color.

### ViewModels
1. **BaseViewModel**: A base class for view models (currently empty).
2. **ChatViewModel**: A view model for chat functionality (currently empty).
3. **QNAViewModel**: A view model for QNA functionality (currently empty).
4. **SettingsViewModel**: A view model for settings functionality (currently empty).

## Main Components

### MainWindow
The MainWindow serves as the primary container for the application. It includes:
- A top bar for navigation between QNA, Chat, and Settings views.
- A side bar for chat history or additional navigation.
- A content area that switches between QNA, Chat, and Settings views.
- A chat interface with a message list, typing indicator, and input area.

### QNAView
Currently a placeholder view for the QNA generation functionality.

### SettingsView
Currently a placeholder view for application settings.

### AppTopBar
A custom control that provides navigation between the main sections of the application:
- QNA
- Chat
- Settings

### AppSideBar
A custom control that provides:
- A toggle button to expand/collapse the sidebar
- A list of chat sessions

### TypingIndicator
A custom control that displays an animated "typing" indicator with three bouncing dots.

## Styling and Theming
The application uses a dark theme with custom styles for various controls:
- Background colors: #343541 (main), #202123 (sidebar)
- Custom button styles with hover and press effects
- Custom chat bubble styles
- Animated typing indicator

## Current State and Next Steps
The application is in the early design stage with the basic structure and UI components in place. The next steps in development could include:
1. Implementing the core QNA generation functionality
2. Developing the chat interface and logic
3. Creating a settings page with relevant options
4. Integrating with an LLM API for question and answer generation
5. Implementing data persistence for chat history and settings
6. Adding user authentication and multi-user support
7. Enhancing the UI with more interactive elements and animations
8. Implementing error handling and logging
9. Adding unit tests and integration tests

## Conclusion
The QNAGen project has a solid foundation with a well-structured WPF application. It uses modern WPF practices such as MVVM architecture, custom controls, and converters. The next phase of development should focus on implementing the core functionality and refining the user experience.