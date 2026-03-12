# ChronoPortals

## Poster
Add project poster image here.

---

# Introduction

**ChronoPortals** is an immersive Extended Reality (XR) experience that allows users to travel through different periods of human history and technological development. By entering interactive portals, users can explore how society, technology, and everyday life have evolved across time.

The experience takes users through four different eras:

- **1900 – Early Industrial Life**
- **1950 – Post-War Technological Development**
- **2000 – Digital and Internet Age**
- **2050 – Future Smart Technology Society**

Each environment represents a unique stage of technological advancement and social change.

Traditional learning about history or technological evolution through books or videos is often passive. It can be difficult for users to imagine how people lived or how technology influenced daily life in different periods.

**ChronoPortals solves this problem by allowing users to experience history directly in immersive virtual environments.** Through exploration and interaction, users can observe and understand the technological transformation of society.


---

# Design Process

Our design process focused on creating an engaging and educational VR experience while staying realistic and achievable in our timeframe.

**Brainstorming**  
We started with a whiteboard session to list ideas for interactions, eras, and immersive elements. We voted on concepts to pick the most feasible and interesting.

**User Research**  
We interviewed classmates to understand what makes VR historical experiences enjoyable and clear. We wanted visible cues, sound, and simple interactions.

**User Persona**  
Our target users are students or anyone interested in history and technology. They are curious, enjoy exploration, and prefer hands-on learning.

**User Journey**  
Users start in the main room, go through a portal, explore the era, hover or touch objects to unlock the next era, and return to the loop. Each transition is designed to be intuitive and visually clear.

**Prototypes**  
We tested different portal designs, 360° videos, 360° images, and object interactions in Unity. Early tests helped us find the right scale for objects and portals and confirmed that users could follow the time travel loop naturally.

---

# System Description

## Features

ChronoPortals includes the following features:

- Four immersive environments representing **1900, 1950, 2000, and 2050**
- Direct interactions: users hover over or touch objects to open portals
- Interactive portals connecting the different eras
- 360° skybox environments for immersive scenes
- Audio and haptic feedback for user interactions
- Information panels
- Looped experience: after visiting 2050, users return to the present
- Supports 6 degrees of freedom: users can move their head and body freely
 - Tangible interaction system using external hardware
- WebSocket communication between Unity and ESP32
- Physical restart button to restart the entire experience

Watch the demo video here: XR Time Machine Demo

---

# Screenshots

Below are some example environments from the experience.

<p align="center">
  <img src="https://github.com/user-attachments/assets/9fea6c5b-d08c-460f-aad1-560993c374ae" width="500">
  <img src="https://github.com/user-attachments/assets/8a2ad40f-a8dd-4859-9799-60f3be548632" width="500">
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/d835de12-25ab-4916-a64c-44ee6a835587" width="500">
  <img src="https://github.com/user-attachments/assets/aef36d3a-7f42-442c-81d2-62a0d65f2d23" width="500">
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/3bd36b35-9c55-4a1a-a185-ae193c026d25" width="500">
  <img src="https://github.com/user-attachments/assets/c04f6d13-c410-4dc4-9aee-d9a0a9ea262d" width="500">
</p>

---

# Configuring Unity and Building for Meta Quest 2

To run XR Time Machine on a Meta Quest 2 headset, the Unity project needs to be set up properly for Android VR. Follow these steps carefully.

## Step 1: Switch Unity to Android Platform

Open your project in Unity Editor.

Go to the top menu:

File → Build Settings

Select Android in the platform list.

Click Switch Platform. This may take a few minutes.

Switching to Android ensures the project can be built as an APK that runs on the Quest 2.

---

## Step 2: Install Required Packages

Open the Package Manager:

Window → Package Manager

Install these packages:

- XR Plugin Management – required to enable VR support  
- XR Interaction Toolkit (XRIT) – required for hand interactions and object manipulation  

Make sure you install the latest stable versions compatible with your Unity version.

---

## Step 3: Enable OpenXR

Go to:

Edit → Project Settings → XR Plug-in Management

Enable OpenXR for both Desktop and Android profiles.

Under:

Project Settings → XR Plug-in Management → Project Validation

Click Fix All.

Some warnings might appear, but they can be ignored.

OpenXR is the standard VR API that works with Meta Quest 2, making it easier to manage interactions and VR input.

---

## Step 4: Configure XR Interaction Toolkit

Add Direct Interactors to both left and right controllers in your XR Rig (not Ray Interactors).

This allows users to grab and interact with objects naturally in VR.

Test your controller setup in the Play Mode to make sure movement and interactions work as expected.

---

## Step 5: Build the APK for Meta Quest 2

Go to:

File → Build Settings

Make sure Android is selected as the platform.

Check Scenes in Build to include your main scene.

Click Player Settings in the Build Settings window.

Set:

- Company Name  
- Product Name  
- Minimum API Level to Android 19 or higher  

Under XR Settings ensure OpenXR is selected.

Connect your Meta Quest 2 headset to your computer via USB.

Enable Developer Mode on the Quest 2 if it is not already enabled.

Click Build and Run.

Unity will compile the project into an APK and install it on the Quest 2.

Once installed, the headset will automatically launch the app.

After building, always test the app on the headset to check that portals, interactions, and 360° videos work as intended.

---

# Installation

To install and run XR Time Machine on Meta Quest 2 or Android:

| Platform | Device | Requirements | Commands / Steps |
|--------|--------|-------------|----------------|
| Android | Meta Quest 2 | Android 19+, XR Plugin Management, OpenXR | `git clone https://github.com/nuryll/XRGroupProject.git` <br> open MainScene.unity <br> Switch Platform to Android <br> Build and Run |

### Dependencies and Libraries

- XR Plugin Management – enables OpenXR support  
- XR Interaction Toolkit (XRIT) – for object interactions and controller support  
- OpenXR – ensures compatibility with Meta Quest 2  

Note: Direct Interactors are used for hand interactions; Ray Interactors are not included in this project.

---

# Tangible Interaction

ChronoPortals integrates **tangible interaction** by connecting physical hardware with the virtual experience.

This is achieved using an **ESP32 microcontroller** that communicates with Unity through **WebSocket communication**.

Through this system, physical actions performed in the real world can trigger events inside the VR environment.

---

## Physical Restart Button

A **physical restart button** is connected to the ESP32 microcontroller.

When the button is pressed:

1. The ESP32 sends a WebSocket message to Unity.
2. Unity receives the message and restarts the VR experience.

---

# Hardware Setup (ESP32 + VR Integration)

The tangible interaction system uses an **ESP32 microcontroller**, a **physical button**, and a **WiFi network** to communicate with the Unity VR application.

---

## Hardware Components

The hardware setup includes:

- ESP32 microcontroller
- Physical push button
- WiFi network
- Meta Quest 2 headset running the Unity application

---

# Usage

- Moving around: physically walk in your space; smooth movement is optional  
- Interacting with objects: hover or touch objects to open portals  
- Portals: Touching or interacting with objects activates **ChronoPortals**, which transport users to another time period.  
- Looping: after reaching 2050, return to the present environment and restart the journey  
- Audio & Haptics: users receive sound and vibration feedback when interacting with objects and portals
- Restart: The experience can be restarted by pressing the **physical  restart button connected to the ESP32**.


### Tips for best experience

- Make sure your play area is clear for physical movement  
- Test each portal individually before experiencing the full loop  
- Focus on interacting with highlighted objects to unlock portals  

---

# References

- [Meta Interaction SDK Samples](https://www.meta.com/en-gb/experiences/interaction-sdk-samples/5605166159514983/) – Official Meta documentation and sample projects for hand interactions in VR.
- [Unity XR Interaction Toolkit Documentation](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest) – Unity official documentation for XRIT setup and usage.
- [OpenXR Plugin for Unity](https://docs.unity3d.com/Packages/com.unity.xr.openxr@latest) – Unity OpenXR package documentation for VR/AR cross-platform support.

---

# Contributors

- Esma Nur Yucel
- Nikou Yousefzadeh Gandovani
- Theekshani Gunarathna

