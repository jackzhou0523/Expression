// external function
EXTERNAL ADVANCE_TIME()

// include 
INCLUDE Dorm.ink
INCLUDE Hunt.ink
INCLUDE Auditorium.ink
INCLUDE Map.ink



// portrait value matching the animation state
=== test ===
Y or No #speaker:Host
Y or N? 
* Yes
    Good job!
* NO
    Nahhhhh!
- 
~ ADVANCE_TIME()
-> END