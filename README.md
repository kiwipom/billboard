# billboard

## What are you doing with your time?

### Context

So I'm going to sit down one Sunday afternoon (well, 22/7 actually) and try and build this app over the course of a day. For people who are interested, I'm looking to broadcast it on ustream and have different ways to get involved (JabbR/Skype/??).

I know many people are going to be interested in the code, so I'll probably just publish the source on GitHub (here) anyway.

And If I hear anyone say "to-do list" I am just gonna snap ([citation](http://www.imdb.com/title/tt0112508/quotes?qt=qt0403077)).

### Plan

I'll probably kick this off at lunchtime AEST Sunday (GMT +10, synchronise your watches). I'll be doing some prep today on the plumbing and spike tasks so I can be productive from the get-go.

Follow me on [twitter](https://twitter.com/shiftkey) or check back here for details about how to get involved - I'll post updates there before, during and after the event.

Note: if you are not around for this, don't worry. If it isn't a spectacular technical failure and people enjoy it I'll try and organise some other events like it in the future.

And if you're expecting a professional broadcasting coding session out of me, here's my reply:

![](http://i.imgur.com/7jcQC.jpg)

I am however open to suggestions on this front.

### Goals
 - keep it simple, stupid
 - provide feedback to the user and identify trends
 - introduce some of the lean/kanban concepts in reporting (continuous flow diagrams? burn down charts?)
 - adapt to the available screen

### Screens
 - Dashboard - see bucket sizes at a glance, and important tasks to address
   - Snapped View - display buckets at top, then notifications
 - Bucket - reorder tasks on priority, move task to next bucket
   - Snapped View - list of items in current bucket
 - Add/Edit Task - provide details about a task - name, size, target date, category?
   - Snapped View - squashed edit form
   - Q: is this a popup for the bucket page? Or standalone page?
 - Reports - browse pre-defined reports (last week, current progress, etc) or customise filters on available data
   - Snapped View - ???
 - Settings - rename buckets, configure constraints, other settings

### Domain

There may be other bits which we need to track but I think this should be enough to get us started:

 - Bucket
    - Id
    - Description
    - Order
    - Collection of Tasks

 - Task
    - Id
    - Title
    - Description
    - TargetDate
    - Size (small, medium, large)
    - Category

 - TaskEvent
   - TaskEventId
   - TaskId
   - BucketId
   - EventTime

That third class represents the events of a user moving items between buckets - this becomes the source of data for reporting.

### Cool things to do:

 - PropertyChanged.Fody - because manual INPC is silly
 - Toast/Tile notifications - task reminders
 - Dogfood the Telerik Metro controls - Date Picker, Charts, sliders etc
 - syncing data between devices
 - testing - what can I show off?

### Spike tasks:

 - settle on a colour scheme for the app
 - Touch - can i leverage OOTB stuff or do I need to craft up something custom?
 - sqlite backing store - i've heard people have had issues with this
 - dogfood some side-projects - AsyncErrorHandler, HAMMER.Pants
 - Mockup screenshots (if possible)