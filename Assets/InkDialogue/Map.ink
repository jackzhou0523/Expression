=== Map_Day1_Afternoon ===
// (Outside, a group of students has gathered, holding signs and chanting in protest. They are following all school policies and the principles of academic freedom to legally express their disagreement.)
Now these students? They’re easy to deal with. The ones who think sheer numbers make them right, though… that’s another story. #speaker:Poli  #portrait:Poli//smiling
Ah—wait, isn’t that Norm over there? #speaker:Law #portrait:Law
// (A character with a unique sprite waves at you from within a group of generic protesters.)
Norm… I swear I heard you shouting in there. You know Heckler’s Veto is— #speaker:Law #portrait:Law
Look, that guy’s speech was awful—totally against public decency! No logic, just nonsense. #speaker:Norm #portrait:Norm //ignoring law 
// (He sighs before turning to you with a small grin.)
But hey, at least this time I listened to Poli and protested properly outside. #speaker:Norm #portrait:Norm
// (The group starts walking forward together.)
    * Call Norm out—you saw them leading the heckling inside. #speaker:You #portrait:default
    ->ExposingNorm
    * Stay silent—you secretly wanted the speaker off the stage too. #speaker:You #portrait:default
    -> StayingSilent
    
=== ExposingNorm ===
You: Wait a second. You were the one who started yelling first!
// (Norm freezes. Law crosses his arms, unimpressed.)
Caught red-handed. #speaker:Law #portrait:Law
// (Poli sighs, rubbing his temples.)
Well, this is a mess. We’ll have to sort this out in a student council meeting. #speaker:Poli #portrait:Poli
~ ADVANCE_TIME()
->END

=== StayingSilent ===
(You say nothing. Norm smirks, nudging you playfully before slipping something into your hand—a piece of candy.)
Consider it a thank-you. #speaker:Norm #portrait:Norm
// (The screen fades to black. The first day ends.)
~ ADVANCE_TIME()
->END