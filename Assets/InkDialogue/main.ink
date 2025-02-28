// external function
EXTERNAL ADVANCE_TIME()
EXTERNAL LOAD_MAP()

// include 
INCLUDE Dorm.ink
INCLUDE Hunt.ink
INCLUDE Auditorium.ink
INCLUDE Map.ink



// portrait value matching the animation state
=== test ===
Yes or No? #speaker:Host #portrait:Host_default #layout:left
Y or N? 
// choices
* Yes
    Good job!
* NO
    Nahhhhh!
- 
-> END