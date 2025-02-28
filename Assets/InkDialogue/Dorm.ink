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
Hey! Get your shoes on—we’re going to the auditorium. #speaker:Poli #portrait:Poli
Huh? What’s happening? #speaker:You #portrait:default
Guest speaker. Big one. You’re in that social science elective, right? This topic’s actually on your syllabus. #speaker:Poli #portrait:Poli
And why exactly should I care? #speaker:You #portrait:default
 (leans in, whispering) Because it’s controversial. #speaker:Poli #portrait:Poli
(raising an eyebrow) Wait—how did the school even approve this if it’s controversial? #speaker:You #portrait:default
(grinning) Academic freedom.#speaker:Poli #portrait:Poli

* Oh, I see. That explains it.
    -> 1A
* Wait, what is academic freedom?
    -> 1B
=== 1A ===
(You nod in understanding.)
Got it. Let’s go, then. #speaker:You #portrait:default
Took you long enough. #speaker:Poli #portrait:Poli
~ LOAD_MAP()
->END
=== 1B ===
(crossing arms)Okay… and that means? #speaker:You #portrait:default
(Poli sighs, already seeing where this is going. They rub their temple before launching into an explanation.) #speaker:  #portrait:default
Alright, let’s make it simple. Imagine you’re a professor. You want to talk about a topic—let’s say, um… climate change. Some people love that topic, others get real mad about it. #speaker:Poli #portrait:Poli
Okay… #speaker:You #portrait:default
Now, let’s say the school only allows climate change discussions if the professor believes it’s fake. #speaker:Poli #portrait:Poli
(blinking) …That sounds dumb. #speaker:You #portrait:default
Exactly. That’s why academic freedom exists—it means universities can’t just ban certain ideas because people don’t like them. You can teach different viewpoints, even unpopular ones. #speaker:Poli #portrait:Poli
(thinking) So, the school has to let anyone speak, no matter what? #speaker:You #portrait:default
(finger wag) Not anyone. If it’s illegal—like a direct threat—they can stop it. But just having an unpopular opinion? That’s protected. #speaker:Poli #portrait:Poli
Even if students don’t like what’s being said? #speaker:You #portrait:default
Yep. Universities are supposed to challenge you, not make you comfortable. That’s kinda the point. #speaker:Poli #portrait:Poli

* Alright, I get it now. Let’s go.
    -> 2A
* But what if a speaker says something really messed up?
    -> 2B

=== 2A ===
~ LOAD_MAP()
->END
=== 2B ===
(inner monologue) Huh. Never thought about it that way. But still, if the speaker's views are really extreme, wouldn’t that cause problems? #speaker:You #portrait:default
And what happens if a speaker says something really messed up? #speaker:You #portrait:default
Okay, let’s say there’s a guest speaker who says… I don’t know, ‘All dogs are evil and should be banned from society. #speaker:Poli #portrait:Poli
(raising an eyebrow) …Weird example, but okay. #speaker:You #portrait:default
Now, if that speaker is just expressing their weird dog-hating opinion, they’re protected. You don’t have to agree, you can protest outside, you can debate them, you can write an angry essay about how amazing dogs are. #speaker:Poli #portrait:Poli
And if they cross the line? #speaker:You #portrait:default
If they start encouraging people to go out and harm dogs? Boom. Not protected anymore—that’s inciting violence. That’s where the school can step in.#speaker:Poli #portrait:Poli
(nodding) Okay, now I get it. #speaker:You #portrait:default
Finally! Come on, I don’t want to miss the drama.#speaker:Poli #portrait:Poli
~ LOAD_MAP()
-> END
