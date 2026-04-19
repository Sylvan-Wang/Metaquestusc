## Screenshot Usage Rules (Important)

All UI is screenshot-based. We are NOT rebuilding the interface in Unity.

Each PNG represents a full UI state and should be treated as a complete screen.

### 1. Base Setup (Unity)

- Create a Canvas (Screen Space - Camera or Overlay)
    
- Add one main RawImage or Image component:  
    → This is the "Laptop Screen"
    
- All screenshots will be swapped on this component
    

---

### 2. Screen Switching (Core Mechanism)

DO NOT build dynamic UI.

Instead:

- Load PNG as Sprite or Texture
    
- On interaction:  
    → Replace the current image with the target screen
    

Example:

month2_inbox → click email → switch to month2_email_02

---

### 3. Hotspot System (Critical)

Hotspots are invisible buttons placed on top of the screenshot.

Implementation:

- Add Button (or collider)
    
- Set Alpha = 0 (invisible)
    
- Position it over clickable area
    

Each hotspot maps to:

→ Target screen  
→ Optional trigger (sound / popup)

---

### 4. How to Define Hotspots

Hotspots should NOT be guessed.

Use normalized coordinates:

Format:

- x: 0–1 (left → right)
    
- y: 0–1 (bottom → top)
    
- width / height: 0–1
    

Example:

Email Row Click Area:  
x: 0.15  
y: 0.55  
w: 0.7  
h: 0.08

---

### 5. Interaction Model

All interactions follow:

Click → Switch Screen → Optional Trigger

NO dynamic layout logic needed.

---

### 6. Overlay vs Full Replacement

We use BOTH approaches:

#### Full Screen Replacement (default)

Used for:

- email open
    
- yes/no clicked
    
- stage transitions
    

#### Overlay (optional, lightweight)

Used for:

- iMessage popup
    
- notification popups
    

Implementation:

- Add second Image layer on top
    
- Toggle visibility
    
- Do NOT rebuild UI
    

---

### 7. Stage Handling

Unity controls stage, NOT the screenshots.

Screens are stateless.

Unity should:

- track current stage
    
- decide which screens are available
    
- trigger events accordingly
    

---

### 8. Naming Convention (Important)

Use filename as state ID.

Example:

- month2_inbox
    
- month2_email_02
    
- month2_yes_clicked
    
- month5_no_response_state
    

Switching logic should directly reference filenames.

---

### 9. Interaction Restrictions by Stage

Month 1 / Month 2:

- Email clickable
    
- YES / NO clickable
    

Month 5:

- Email clickable
    
- NO response buttons
    
- clicking does NOT resolve anything
    

Final:

- Only voicemail is interactive
    

---

### 10. Minimal Required System

Unity only needs:

- Image switch system
    
- Hotspot system
    
- Simple timer triggers
    
- Audio trigger system
    

DO NOT build:

- full email system
    
- real chat system
    
- dynamic UI rendering
    

---

### 11. Key Principle

We are simulating interaction, not building real software.

Focus on:

- correct timing
    
- correct transitions
    
- emotional pacing