// State of going back to dorm
VAR DayXDorm = "DayXDorm"
=== Dorm ===
{ DayXDorm :
    - "Day1Dorm" : -> Day1Night
    - "Day2Dorm" : -> Day2Night
    - "Day3Dorm" : -> Day3Night
    - "Day4Dorm" : -> Day4Night
    - "Day5Dorm" : -> Day5Night
    - else: -> END
}

= Day1Night 
->END
= Day2Night 
->END
= Day3Night 
->END
= Day4Night 
->END
= Day5Night 
->END


=== Start_Dorm_Intro ===
(The protagonist clicks on an email notification.)
Inner monologue: This class was really hard to get into this year.
(The email reads:)
    Subject: Welcome to [Course Name] – A Note on Reports\nDear Students,
    The semester hasn't officially begun yet, but I encourage you to develop good habits early.
    Writing reports will be an essential part of this class, and I’ll be offering extra credit for students who submit a brief reflection on any relevant topics. 
    Consider this an opportunity to sharpen your analytical skills. Looking forward to seeing you all soon! 
    Best, [Professor's Name]
(A knock on the door..)
Poli! What brings you here? #speaker:You
Come on, there's a guest speaker today. Didn’t you enroll in some social science elective? This guy’s topic is actually on your syllabus. #speaker:Poli
Oh? That kind of topic is pretty controversial. How did the school even approve his lecture? #speaker:You
Don’t forget—under academic freedom, we can’t selectively protect some speakers while banning others based on their viewpoint. (He smirks, motioning you to follow him.) #speaker:Poli
No more questions—just come already! I’ll be waiting at the auditorium. 
-> END
