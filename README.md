# Coding Time Tracker

This is a project following the C# academy here: https://www.thecsharpacademy.com/#

I'm taking a bit of a different approach than they show in the requirements based on what makes more sense to me

# Main Changes

One of the main changes I'm making is the inputting of start and end times. They say to do it by getting input from the user about what time they started and ended and I didn't like that so this is what I'm opting for:

* Separate StartLog and EndLog commands
    - StartLog will get your current DateTime.Now() and then make sure there's not an already started log (aka a row in the SQL Database with a StartTime but no EndTime/Duration)
    - EndLog will do the same but as the inverse, setting the DateTime.Now() as the EndTime for the row without an EndTime if there is one, and if not it will prompt you to start one.