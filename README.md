# Braille Learning Tool

The Braille Learning Tool is an accessible Unity educational application specifically designed for visually impaired individuals to learn Braille characters through audio-guided interactive experiences. The app focuses on accessibility, featuring comprehensive audio instructions, simple navigation, and clear feedback systems.

## ✨ Features

- **🏠 Home Screen**: Central navigation hub with audio instructions for accessibility
- **📚 Learning Mode**: Introduces Braille characters with audio guidance and interactive dot patterns
- **🎯 Practice Mode**: Tests and improves Braille recognition skills with audio feedback
- **ℹ️ About Section**: Information about the application and development team
- **🔊 Audio Instructions**: Comprehensive audio guidance throughout the application
- **♿ Accessibility Focused**: Designed specifically for visually impaired users
- **🎨 High Contrast UI**: Clear, simple interface with large buttons and readable text

<h2>📸 Screenshots</h2>

<table>
  <tr>
    <th>Home Screen</th>
    <th>Learning Mode</th>
    <th>Practice Mode</th>
    <th>About Screen</th>
  </tr>
  <tr>
    <td align="center">
      <img width="150" src="https://github.com/user-attachments/assets/e1618e56-f90f-4247-9503-af4b84537118" alt="Home Screen" />
    </td>
    <td align="center">
      <img width="150" src="https://github.com/user-attachments/assets/d5db4a20-862e-43cf-bd92-c3e22cf902ab" alt="Learning Mode" />
    </td>
    <td align="center">
      <img width="150" src="https://github.com/user-attachments/assets/f6a32598-3f7e-4fe5-8024-c2195e4c8c62" alt="Practice Mode" />
    </td>
    <td align="center">
      <img width="150" src="https://github.com/user-attachments/assets/7c6d4b96-5b72-4705-8b5f-f18b2a842f66" alt="About Screen" />
    </td>
  </tr>
  <tr>
    <td align="center"><em>Main navigation with three mode options</em></td>
    <td align="center"><em>Interactive Braille character learning with audio guidance</em></td>
    <td align="center"><em>Interactive Braille character practice with audio guidance</em></td>
    <td align="center"><em>Application information and team details</em></td>
  </tr>
</table>

## 🚀 Installation

### Prerequisites
- Unity 2022.3.55f1 or later
- Git for version control

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/nuriacurry/Braille-Learning-Tool.git
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Open" and select the cloned project folder
   - Wait for Unity to import all assets

3. **Build Settings**
   - Go to File → Build Settings
   - Ensure all scenes are added to the build:
     - HomeScene
     - LearningMode
     - PracticeMode
     - About

4. **Run the Application**
   - Press Play in Unity Editor to test
   - Or build for your target platform (Windows, Mac, Mobile)

## 🎮 How to Use

### For Developers
1. Open the project in Unity
2. Start from the HomeScene
3. All scenes are connected through the navigation system
4. Audio files are managed through the HomeAudioManager

### For Users
1. Launch the application
2. Listen to the audio instructions that play automatically
3. Use the three main buttons to navigate:
   - **Learning Mode**: Learn individual Braille characters
   - **Practice Mode**: Test your knowledge
   - **About**: Learn about the application
4. Use the Home button to return to the main menu from any screen

## 🛠️ Technology Stack

- **Game Engine**: Unity 2022.3.55f1
- **Programming Language**: C#
- **UI System**: Unity Canvas UI
- **Audio System**: Unity AudioSource components
- **Version Control**: Git/GitHub
- **Platform**: Windows, Mac, Linux (expandable to mobile)

## 👥 Team

| Name | Role | Contributions |
|------|------|---------------|
| **Nuria Siddiqa** | Team Coordinator | Debug management, GitHub handling, UI development, audio implementation |
| **Jannatul Naima** | Frontend Developer | HomeScreen & About screen creation, navigation implementation, audio integration |
| **Mekhribon Yusufbekova** | Backend Developer | Learning & Practice modes, letter functionality, audio development |

## 🤝 Contributing

We welcome contributions to improve the Braille Learning Tool! Here's how you can help:

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Make your changes**
4. **Commit your changes**
   ```bash
   git commit -m "Add: description of your feature"
   ```
5. **Push to your branch**
   ```bash
   git push origin feature/your-feature-name
   ```
6. **Open a Pull Request**

### Development Guidelines
- Follow existing code style and naming conventions
- Test your changes thoroughly
- Update documentation as needed
- Ensure accessibility features remain intact

## 🔮 Future Enhancements

- [ ] Add more Braille symbols beyond the basic alphabet
- [ ] Implement user profiles to track long-term progress
- [ ] Add functionality for tapping anywhere to repeat audio instructions
- [ ] Enhance Learning Mode with improved audio feedback
- [ ] Change audio sounds for Learning Mode to better indicate dot positions
- [ ] Create advanced practice mode with word challenges
- [ ] Add haptic feedback for mobile devices
- [ ] Implement multiple language support
- [ ] Add progress tracking and statistics

## 📁 Project Structure

```
Assets/
├── Audio/
│   ├── AboutScreen        🎵
│   └── homeScreen         🎵
├── Materials/
├── Resources/
├── Scenes/
│   ├── About
│   ├── HomeScene
│   ├── LearningMode-A
│   ├── LearningMode-B
│   ├── LearningMode-C
│   ├── LearningMode-D
│   ├── LearningMode-E
│   ├── LearningMode-F
│   ├── LearningMode-G
│   ├── LearningMode-H
│   ├── LearningMode-I
│   ├── LearningMode-J
│   ├── LearningMode-K
│   ├── LearningMode-L
│   ├── LearningMode-M
│   ├── LearningMode-N
│   ├── LearningMode-O
│   ├── LearningMode-P
│   ├── LearningMode-Q
│   ├── LearningMode-R
│   ├── LearningMode-S
│   ├── LearningMode-T
│   ├── LearningMode-U
│   ├── LearningMode-V
│   ├── LearningMode-W
│   ├── LearningMode-X
│   ├── LearningMode-Y
│   ├── LearningMode-Z
│   └── PracticeMode
├── Scripts/
│   ├── AboutSceneController.cs
│   ├── AudioManager.cs
│   ├── BrailleButton.cs
│   ├── BrailleDatabase.cs
│   ├── BrailleDotButton.cs
│   ├── BrailleGridManager.cs
│   ├── BrailleTester.cs
│   ├── ButtonSoundConnector.cs
│   ├── HomeAudioManager.cs
│   ├── HomeScreenController 2.cs
│   ├── KeyboardInputHandler.cs
│   ├── LearningModeController.cs
│   ├── SceneLoader.cs
│   └── SimpleAudioPlayer.cs
├── Sounds/
├── Sprites/
├── TextMesh Pro/
└── TextMesh Pro 2/
```

## 🙏 Acknowledgments

- Thanks to our course instructor for guidance throughout development
- Inspiration from existing Braille learning tools
- Feedback from visually impaired test users was invaluable

## 📞 Support

If you encounter any issues or have questions:
- Open an issue on GitHub
- Contact the development team through the repository

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Made with ❤️ for accessibility and inclusive education**
