// include 
INCLUDE Dorm.ink
INCLUDE Hunt.ink

// portrait value matching the animatio state
=== test ===
Y or N? #speaker:Host #portrait:default #layout:left
* Yes
    Good job!
* NO
    Nahhhhh!
- -> END

=== Chapter1 ===
Good evening, everyone. Thank you for joining us today. We’re honored to have a distinguished guest speaker with us…… #speaker:Host #portrait:Host_default #layout:right
(Your phone vibrates. You glance down—your friend just sent you a link to the school forum. A breaking story is trending: the guest speaker’s controversial views and political stance have been dug up and are spreading fast. Around the room, more people check their phones, whispering to each other. The once-settling crowd grows restless.)
(As the murmuring continues, the guest speaker becomes visibly nervous. Their words stumble.)
Uh, well… I want to start by saying that… (clears throat) …… appreciate the chance to… share my perspective on... #speaker:Speaker
(They try to lighten the mood with a joke—)
You know, they say [Insert bad stereotype-laden joke here], ha…ha…ha… #speaker:Speaker
(Silence. No laughter. Instead, the atmosphere stiffens. People exchange uncomfortable glances.)
(A voice from the audience yells:)
That’s not funny! Apologize! #speaker:Audience Member
(The speaker realizes something is wrong. They stammer, trying to recover, but the more they speak, the worse it gets.)
Look, if you’re offended, that’s… that’s really not my problem. People these days are just too sensitive. Can’t we have real discussions anymore? Or do I need to ask permission before expressing a thought? #speaker:Speaker
(The sarcasm only fuels the anger in the room.)
(More voices rise in frustration—)
"Get off the stage!" "Enough already!" "You’re just spreading ignorance!" #speaker:Audience
(Suddenly, a hand taps your shoulder.)
What you’re seeing right now is called Heckler’s Veto—it’s when… #speaker:???
Law? What are you doing here? #speaker:You
Don’t interrupt. Heckler’s Veto refers to situations where the audience silences a speaker through sheer volume and disruption rather than reasoned debate. It’s a controversial issue in free speech law. #speaker:Law
(You remain silent, processing this as the shouting escalates.)
(Poli is nowhere to be seen. Law glances at you.)
Oh, Poli asked me to come keep an eye on you while he stepped out for a moment. #speaker:Law
(The tension in the auditorium is reaching its peak. You feel uneasy.)
You (inner monologue): This is getting out of control… should I step in?
The student council will listen to you. So, what’s your call—should we de-escalate the situation or uphold the speaker’s legal right to be here? #speaker:Law
    * [The speaker's words are too sensitive and inappropriate. It's best to remove them to maintain order.]
    * [Although unconventional, their views are fully protected under free speech.]
    
- 
(Before you can even voice your choice, campus security enters the scene. The situation is quickly contained. The speaker is escorted offstage before anything escalates further.)
(Poli appears by your side.)
Gotcha. Relax—he paid the content-neutral security fee, so no matter what, we can’t let anything happen to him while he’s on campus. #speaker:Poli
… #speaker:You
Oh, Content-neutral security fees are charges imposed on speakers regardless of their viewpoints to ensure security costs don’t become a tool for selective censorship. #speaker:Poli
(You sigh, realizing you’ve been played. Muttering under your breath, you follow Poli and Law out of the auditorium.)
-> END

=== TheProtesters ===
(Outside, a group of students has gathered, holding signs and chanting in protest. They are following all school policies and the principles of academic freedom to legally express their disagreement.)
Poli (smiling): Now these students? They’re easy to deal with. The ones who think sheer numbers make them right, though… that’s another story.
Law: Ah—wait, isn’t that Norm over there?
(A character with a unique sprite waves at you from within a group of generic protesters.)
Law: Norm… I swear I heard you shouting in there. You know Heckler’s Veto is—
Norm (ignoring Law): Look, that guy’s speech was awful—totally against public decency! No logic, just nonsense.
(He sighs before turning to you with a small grin.)
Norm: But hey, at least this time I listened to Poli and protested properly outside.
(The group starts walking forward together.)
    * Call Norm out—you saw them leading the heckling inside.
    ->ExposingNorm
    * Stay silent—you secretly wanted the speaker off the stage too.
    -> StayingSilent
    
=== ExposingNorm ===
You: Wait a second. You were the one who started yelling first!
(Norm freezes. Law crosses his arms, unimpressed.)
Law: Caught red-handed.
(Poli sighs, rubbing his temples.)
Poli: Well, this is a mess. We’ll have to sort this out in a student council meeting.
->END

=== StayingSilent ===
(You say nothing. Norm smirks, nudging you playfully before slipping something into your hand—a piece of candy.)
Norm: Consider it a thank-you.
(The screen fades to black. The first day ends.)
->END
