# Braille Learning Tool - Detailed Requirements

## 1. Introduction

### Project Overview
This project aims to develop a Unity-based Braille learning tool for blind and visually impaired individuals.

### Purpose and Objectives
To create an accessible educational tool that helps users learn Braille through interactive audio feedback and practice.

### Target Audience
Blind and visually impaired individuals, educators, and family members supporting Braille learning.

## 2. Core Features
### 2.1 Learning Mode Requirements
### High Priority:

- Letter Display System:

    -  Display a letter (A-Z) with clear visual presentation (minimum 36pt font size)
    - Implement high-contrast display options (white on black, yellow on blue, etc.)
    - Provide simultaneous audio announcement using text-to-speech
    - Allow manual navigation through the alphabet (next/previous controls)
    - Support voice announcement of the current letter


- Braille Representation:

    - Highlight the correct Braille dot positions for each displayed letter
    - Use high contrast colors for the highlighted dots
    - Display the standard 3×2 Braille cell layout (2 columns, 3 rows)
    - Maintain consistent spacing between dots


- Audio Feedback System:

    - Announce dot positions verbally (e.g., "Dot 1, Dot 4") when a letter is displayed
    - Provide unique tones for each button when pressed (ascending musical scale)
    - Audio must be clear and distinct with adjustable volume
    - Include option to repeat audio instructions


- Interactive Learning Features:

    - Enable button exploration with audio feedback for each press
    - Provide repeat functionality for current letter and instructions
    - Include a help option that explains how to use the learning mode



### Medium Priority:

- Progression System:

    - Allow sequential navigation through all 26 letters
    - Include "previous" and "next" buttons with clear audio labels
    - Provide a quick-access menu to jump to specific letters
    - Remember the last viewed letter when returning to learning mode


- Visual Customization:

    - Adjustable contrast settings for different vision capabilities
    - Option to change highlight colors
    - Ability to resize the Braille cell display



- Acceptance Criteria:

    - Users can navigate through all 26 letters without assistance
    - Audio feedback correctly announces the currently displayed letter and its dot positions
    - All interactive elements provide appropriate feedback when activated
    - System accommodates both touch and keyboard/switch inputs


    
### 2.2 Practice Mode Requirements

### High Priority:

- Letter Challenge System:

   - Generate random letters (A-Z) with clear audio announcement
   -  Provide option to practice specific letter groups
   -  Announce the challenge letter clearly using text-to-speech
   -  Allow for letter repeat if needed


- User Input Mechanism:

   - Implement double-tap confirmation to prevent accidental selections
   - Register input only when buttons are deliberately pressed
   - Provide clear audio feedback for each button press
   - Support alternative input methods (keyboard, switches) for accessibility


- Feedback System:

   - Provide immediate audio feedback for correct answers ("Correct!")
   - Play distinct error sound for incorrect answers
   - Announce the correct answer after errors with dot positions
   - Keep feedback positive and encouraging


- Error Correction:

   - After incorrect answers, show the correct Braille pattern
   - Verbally explain which dots should have been selected
   - Offer option to retry missed letters more frequently



### Medium Priority:

- Progress Tracking:

   - Record accuracy rates for each letter
   - Track overall session performance
   - Store historical practice data
   - Generate simple performance reports


- Difficulty Levels:

   - Beginner: Only common letters, unlimited time, extra guidance
   - Intermediate: All letters, reasonable time limits, standard feedback
   - Advanced: Include numbers and punctuation, strict time limits, minimal guidance


- Session Management:

   - Allow user to set session length (number of challenges)
   - Provide session summary at the end
   - Option to focus on problem letters



### Low Priority:

- Gamification Elements:

   - Achievement system for mastering letter groups
   - Streak counters for consecutive correct answers
   - Optional time-challenge mode
   - "Personal best" records



- Acceptance Criteria:

    - System correctly identifies and validates user input
    - Performance metrics are accurately tracked and stored
    - Difficulty levels provide appropriately scaled challenges
    - Users can complete practice sessions without assistance
  
## 3. User Interface Requirements

### General Layout

Main menu with options for Learning Mode, Practice Mode, Settings, and Help
Six-button Braille cell layout (2 columns, 3 rows)
Navigation buttons (next, previous, back to menu)
Clear, high-contrast design

### Button Design

Large, easily tappable buttons (minimum 1cm × 1cm)
Clear visual states (normal, pressed, selected)
Consistent positioning across screens

### Audio Feedback

Voice guidance for all screen elements
Unique tones for each Braille dot position
Confirmation sounds for correct/incorrect answers

## 4. Accessibility Requirements
### Visual Accessibility

- High contrast color options
- Large text and buttons
- Screen reader compatibility

### Audio Guidance

- Clear voice instructions
- Customizable speech rate
- Option to repeat instructions

### Haptic Feedback

- Vibration on button press
- Distinct patterns for correct/incorrect answers

## 5. Data Management
### User Progress

- Track completion status for letters
- Record accuracy percentages
- Store session history

### Settings

- Audio volume levels
- Visual contrast preferences
- Difficulty settings

## 6. Technical Requirements
### Unity Implementation

- Unity 2022 LTS version
- UAP (Unity Accessibility Plugin)
- TextMeshPro for text
- Nice Vibrations for haptic feedback

### Target Platforms

- Android and iOS (primary)
- Windows desktop (secondary)
