# MyCoolProject Solution

This project was created using @angular-devkit/schematics.

The architecture is DDD Onion mixed with Hexagonal.

Use the following schematics to generate features:
:net-resource --designer=<<request>>/<<resource>>
* plural: <<resource>>s
* foreach letter in request
    * switch (letter):
        * case C: Command
            * Template: Create | Delete | Replace | Update
            * Model?
            * Validate? T|F = T
            * Log? T|F = T
            * Authorization Policy
        * case Q: Query
            * Template: One | Many
            * Model?
            * Validate? T|F = F
            * Cache? T|F = F
            * Log? T|F = T
            * Authorization Policy