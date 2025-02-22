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


=== Dorm_Day1_Morning ===
Poli! What brings you here? #speaker:You
Come on, there's a guest speaker today. Didn’t you enroll in some social science elective? This guy’s topic is actually on your syllabus. #speaker:Poli
Oh? That kind of topic is pretty controversial. How did the school even approve his lecture? #speaker:You
Don’t forget—under academic freedom, we can’t selectively protect some speakers while banning others based on their viewpoint. (He smirks, motioning you to follow him.) #speaker:Poli
No more questions—just come already! I’ll be waiting at the auditorium. 
-> END
