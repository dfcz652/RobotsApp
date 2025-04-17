Modification of robot parts:

**1. Arms(basic characteristics: Dmg, EnergyCost, ImpactDistance and additional characteristics that depend on the selected part)**

<u>Default arms(hands are deprived of features)</u>
- DefaultArms(Dmg:5, EnergyCost:0, ImpactDistance:1)

<u>Long-range arms(long-range combat is good, but watch your energy)</u>
- PistolArms(Dmg:7, EnergyCost:4, ImpactDistance:6)
- RocketArms(Dmg:10, EnergyCost:5, ImpactDistance:10)

<u>Hand-To-Hand arms(a real man will come forward rather than hide)</u>
- SpearArms(Dmg:12, EnergyCost:0, ImpactDistance:4)
- SwordArms(Dmg:15, EnergyCost:0, ImpactDistance:2)

**2. Body(basic characteristics: Hp and additional characteristics that depend on the selected part)**

<u>Default body(regular legs, "a little rusty")</u>
- DefaultBody(Hp:15)

<u>Heavy bodies(in such knights still fought for the king, probably)</u>
- ArmouredBody(Hp:30, Armor:4)
- TankyBody(Hp:50, Armor:2)

<u>Shield body(suitable for protection from shelling)</u>
- ShieldedBody(Hp:10, Shield:10, ShieldCost:2)

**3. Core(basic characteristics: Energy, EnergyRestoration and additional characteristics that depend on the selected part)**

<u>Default cores(a normal core, like the human heart)</u>
- DefaultCore(Energy:5, EnergyRestoration:3)
- EnergeticCore(Energy:10, EnergyRestoration:5)

<u>Life-support cores(with nice bonuses for battle)</u>
- LivingCore(Energy:8, EnergyRestoration:4, Hp:10)
- ProtectiveCore(Energy:9, EnergyRestoration:4, Shield:5, ShieldCost:1)

**4. Legs(basic characteristics: Speed, Distance and additional characteristics that depend on the selected part)**

<u>Default legs(legs without features but with an unpleasant creak)</u>
- DefaultLegs(MovementSpeed:2, ActionSpeed:2)
- SpeedLegs(MovementSpeed:10, ActionSpeed:5)

<u>Survivial legs(legs that will make the robot fatter)</u>
- ArmouredLegs(MovementSpeed:5, ActionSpeed:2, Armor:3)

<u>EnergeticLegs(for those who like to stand and shoot)</u>
- RechargingLegs(MovementSpeed:5, ActionSpeed:2, EnergyRestoration:3)

Rules for creating robots:

1. Before starting the game, we create two robots that will fight each other.
2. Might to choose parts from the parts list presented from above.
3. Both robots must contain the required parts (arms, body, core and legs).
4. Each robot must contain exactly one part of the required types: arms, body, core, legs.
5. A part must have its basic characteristics.
6. A part also have its non-basic characteristics(which ones exactly depend on the part).
7. Non-basic characteristics not required for each part.
8. Values of existing characteristics cannot be changed.

Functionality:
1. Setting required and optional characteristics to parts.
2. Creating robots.
3. Selecting parts for robot 1.
4. Selecting parts for robot 2.
5. Combining all characteristics for the first and second robot.
6. Output to the console combined characteristics of both robots.