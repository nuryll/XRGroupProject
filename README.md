# XR Time Machine

## Poster
HERE POSTER

---


## Introduction
XR Time Machine is an immersive experience that lets users travel through time and explore how human life and technology have changed. Users can move through four eras—1900, 1950, 2000, and 2050—and interact with objects, portals, and information panels in fully immersive environments.

The experience takes users on a journey through four different years:

- 1900 – Early Industrial Life  
- 1950 – Post-War Technological Development  
- 2000 – Digital and Internet Age  
- 2050 – Future Smart Technology Society  

Each environment represents a different stage in technological development and daily life.

The problem we noticed is that learning about history or technology evolution from books or videos is passive. Users often struggle to imagine how life looked or how technology impacted everyday life.

XR Time Machine solves this by letting users step into the past and future, explore environments, and interact with objects. VR makes it memorable and engaging because users feel like they are physically traveling through time.

---

# Screenshots

Below are some example environments from the experience.

### 1900 – Early Industrial Life
IMAGE HERE

### 1950 – Post-War Technological Development
IMAGE HERE

### 2000 – Digital and Internet Age
IMAGE HERE

### 2050 – Future Smart Technology Society
IMAGE HERE

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

- Four immersive environments representing **1900, 1950, 2000, and 2050**
- Direct interactions: users hover over or touch objects to open portals
- 360° videos for realistic time travel transitions
- Haptic and audio feedback for portals, objects, and interactions
- Educational information panels explaining historical and technological context
- Looped experience: after visiting 2050, users return to the present
- Supports 6 degrees of freedom: users can move their head and body freely

Watch the demo video here: XR Time Machine Demo

---

# Project Structure

The repository is organized as follows:

```
XR-Time-Machine/
│
├── Assets/                # Unity assets, scenes, models, scripts
├── Packages/              # Unity package dependencies
├── ProjectSettings/       # Unity project settings
│
├── docs/                  # Images, poster, screenshots, video references
│
├── README.md              # Project documentation
```

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
| Android | Meta Quest 2 | Android 19+, XR Plugin Management, OpenXR | `git clone https://github.com/user/xr-time-machine.git` <br> `cd xr-time-machine` <br> open MainScene.unity <br> Switch Platform to Android <br> Build and Run |

### Dependencies and Libraries

- XR Plugin Management – enables OpenXR support  
- XR Interaction Toolkit (XRIT) – for object interactions and controller support  
- OpenXR – ensures compatibility with Meta Quest 2  

Note: Direct Interactors are used for hand interactions; Ray Interactors are not included in this project.

---

# Usage

- Moving around: physically walk in your space; smooth movement is optional  
- Interacting with objects: hover or touch objects with controllers to open portals  
- Portals: each portal represents a different era. Hover over objects to unlock the next time period  
- Information panels: access historical facts and technological context  
- Looping: after reaching 2050, return to the present environment and restart the journey  
- Audio & Haptics: users receive sound and vibration feedback when interacting with objects and portals  

### Tips for best experience

- Make sure your play area is clear for physical movement  
- Test each portal individually before experiencing the full loop  
- Focus on interacting with highlighted objects to unlock portals  

---

# References

HERE COME SOME REFERENCES

---

# Contributors

Group 5 – XR Time Machine

OUR NAMES COME HERE

