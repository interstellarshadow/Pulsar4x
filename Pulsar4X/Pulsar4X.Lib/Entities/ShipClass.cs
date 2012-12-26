﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using Pulsar4X.Entities.Components;

namespace Pulsar4X.Entities
{
    public class ShipClassTN
    {
        /// <summary>
        /// Not using these yet, may not use some of them at all.
        /// </summary>
        [Browsable(false)]
        public Guid Id { get; set; }

        [Browsable(false)]
        public Faction Faction { get; set; }

        [Browsable(false)]
        public int HullDescriptionId { get; set; }

        [DisplayName("Required Rank"),
        Category("Detials"),
        Description("Minium Rank needed to command this Class of ship."),
        Browsable(true),
        ReadOnly(true)]
        public int RequiredRank { get; set; }

        [Browsable(false)]
        public int MaxLifeSupport { get; set; } //not sure what life support is supposed to be? deployment time?


        /// <summary>
        /// Name of the class of craft.
        /// </summary>
        [DisplayName("Class Name"), 
        Category("Description"),
        Description("The Name of the Class"),
        Browsable(true),
        ReadOnly(true)]
        public string Name { get; set; }

        /// <summary>
        /// Notes on this ship class, used by the UI/Player.
        /// </summary>
        [DisplayName("Notes"), 
        Category("Description"),
        Description("Notes on this ship class"),
        Browsable(true),
        ReadOnly(false)]
        public string Notes { get; set; }

        [Browsable(false)]
        public BindingList<ShipTN> ShipsInClass { get; set; }

        /// <summary>
        /// Cost in BP of the ship, not its mineral cost, not doing that just yet.
        /// </summary>
        [DisplayName("Cost"), 
        Category("Detials"),
        Description("Cost in BP of the ship."),
        Browsable(true),
        ReadOnly(true)]
        public decimal BuildPointCost { get; set; }

        /// <summary>
        /// Size in tons.
        /// </summary>
        [DisplayName("Size in Tons"), 
        Category("Detials"),
        Description("Size in tons."),
        Browsable(true),
        ReadOnly(true)]
        public float SizeTons { get; set; }

        /// <summary>
        /// Size in tons / 50.0; 1HS = 50 tons.
        /// </summary>
        [DisplayName("Size in HS"), 
        Category("Detials"),
        Description("Size in Hull Sizes (HS), 1HS = 50 tons."),
        Browsable(true),
        ReadOnly(true)]
        public float SizeHS { get; set; }

        /// <summary>
        /// Total Internal Hit to kill of all components. components need not all be destroyed in order for a ship to be destroyed however.
        /// </summary>
        [DisplayName("Total HTK"), 
        Category("Detials"),
        Description("Total Internal Hit to kill of all components."),
        Browsable(true),
        ReadOnly(true)]
        public int TotalHTK { get; set; }

        /// <summary>
        /// Is this ship a military or civilian flagged design?
        /// </summary>
        [Browsable(false)]
        public bool IsMilitary { get; set; }

        /// <summary>
        /// Has the user declared this design obsolete?
        /// </summary>
        [Browsable(false)]
        public bool IsObsolete { get; set; }

        /// <summary>
        /// How many military grade components are part of this ship?
        /// </summary>
        [Browsable(false)]
        public int MilitaryComponentCount { get; set; }

        /// <summary>
        /// What is the perceived protection value this ship class provides to civilians.
        /// </summary>
        [DisplayName("Planetary Protection Value"), 
        Category("Detials"),
        Description("What is the perceived protection value this ship class provides to civilians."),
        Browsable(true),
        ReadOnly(true)]
        public int PlanetaryProtectionValue { get; set; }

        /// <summary>
        /// Armor statistics that matter to the class itself.
        /// </summary>
        [Browsable(false)]
        public ArmorDefTN ShipArmorDef { get; set; }

        /// <summary>
        /// Crew Quarters, Small Crew Quarters, Tiny Crew Quarters.
        /// Every ship has a required crew amount, though for some small sensor only craft it might be 0.
        /// </summary>
        [DisplayName("Crew Quarters"), 
        Category("Component Lists"),
        Description("List of Crew Quarters on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<GeneralComponentDefTN> CrewQuarters { get; set; }

        [DisplayName("Crew Quarters Count"),
        Category("Component Counts"),
        Description("Number of Crew Quarters on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<ushort> CrewQuartersCount { get; set; }
        public int TotalCrewQuarters { get; set; }
        public int TotalRequiredCrew { get; set; }
        public int SpareCrewQuarters { get; set; }
        public int SpareCryoBerths { get; set; }
        public int MaxDeploymentTime { get; set; }
        public float TonsPerMan { get; set; }
        public float CapPerHS { get; set; }
        public float AccomHSRequirement { get; set; }
        public float AccomHSAvailable { get; set; }


        /// <summary>
        /// Fuel Tanks, Small Fuel Tanks, Tiny Fuel Tanks, Large Fuel Tanks, Very Large Fuel Tanks, Ultra Large Fuel Tanks.
        /// Should fuel compression be a tank type or an option? Base fuel storage is Tons * 1000.
        /// </summary>
        [DisplayName("Fuel Tanks"),
        Category("Component Lists"),
        Description("List of Fuel Tanks on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<GeneralComponentDefTN> FuelTanks { get; set; }

        [DisplayName("Fuel Tanks Count"),
        Category("Component Counts"),
        Description("Number of Fuel Tanks on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<ushort> FuelTanksCount { get; set; }

        [DisplayName("Total Fuel Capacity"),
        Category("Detials"),
        Description("The Total Fuel Capacity of the ship."),
        Browsable(true),
        ReadOnly(true)]
        public float TotalFuelCapacity { get; set; }

        /// <summary>
        /// Engineering bay, Small Engineering Bay, Tiny Engineering Bay, Fighter Engineering Bay.
        /// Ebays give 3 benefits, they increase MSP, they give a minor boost to damage control and they reduce failure rate for military vessels.
        /// Base Ebay storage is handled in a bizarre manner. 4% hull space of ebays = normal failure rate, and enough parts in BP to cover 1/2 the cost of the ship.
        /// </summary>
        [DisplayName("Engineering Bays"),
        Category("Component Lists"),
        Description("List of Engineering Bays on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<GeneralComponentDefTN> EngineeringBays { get; set; }

        [DisplayName("Engineering Bays Count"),
        Category("Component Counts"),
        Description("Number of Engineering Bays on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<ushort> EngineeringBaysCount { get; set; }

        [DisplayName("Total MSP Capacity"),
        Category("Engineering Detials"),
        Description("The Total MSP Capacity of the ship."),
        Browsable(true),
        ReadOnly(true)]
        public int TotalMSPCapacity { get; set; }

        [DisplayName("Engineering HS"),
        Category("Engineering Detials"),
        Description("Total size, in HS, dedicated to Engineering bays."),
        Browsable(true),
        ReadOnly(true)]
        public float EngineeringHS { get; set; }

        [DisplayName("Maintenance Life"),
        Category("Engineering Detials"),
        Description("The Maintenance Life of the ship."),
        Browsable(true),
        ReadOnly(true)]
        public float MaintenanceLife { get; set; }

        [DisplayName("Annual Failure Rate"),
        Category("Engineering Detials"),
        Description("The estimated Annual Failure Rate of the ship."),
        Browsable(true),
        ReadOnly(true)]
        public float AnnualFailureRate { get; set; }

        [DisplayName("Initial Failure Rate"),
        Category("Engineering Detials"),
        Description("The estimated Initial Failure Rate of the ship, i.e. the Failure rate when the Ship has just left the yard."),
        Browsable(true),
        ReadOnly(true)]
        public float InitialFailureRate { get; set; }

        public float YearOneFailureTotal { get; set; }
        public float YearFiveFailureTotal { get; set; }
        public int MaxDamageControlRating { get; set; }
        public int MaxRepair { get; set; }

        /// <summary>
        /// Bridge, Flag Bridge, Damage Control, Improved Damage Control, Advanced Damage Control, Maintenance bay, Recreational Facility, Orbital Habitat.
        /// Each gives a fairly specialist benefit that not all ships will need, excepting the bridge of course.
        /// </summary>
        [DisplayName("Other Components"),
        Category("Component Lists"),
        Description("List of Other Components on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<GeneralComponentDefTN> OtherComponents { get; set; }

        [DisplayName("Other Componenmts Count"),
        Category("Component Counts"),
        Description("Number of Other Componenmts on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<ushort> OtherComponentsCount { get; set; }
        [Browsable(false)]
        public bool HasBridge { get; set; }

        /// <summary>
        /// each ship class can only have one type of engine, though several copies may be present.
        /// </summary>
        [DisplayName("Ship Engine Model"),
        Category("Engine Stats"),
        Description("The model/type of this ships engines"),
        Browsable(true),
        ReadOnly(true)]
        public EngineDefTN ShipEngineDef { get; set; }

        [DisplayName("Max Fuel Usage"),
        Category("Engine Stats"),
        Description("The maximum fuel usage per hour of this ships engines"),
        Browsable(true),
        ReadOnly(true)]
        public float MaxFuelUsePerHour { get; set; }

        [DisplayName("Engine Count"),
        Category("Engine Stats"),
        Description("The number of engines in this ship."),
        Browsable(true),
        ReadOnly(true)]
        public ushort ShipEngineCount { get; set; }

        /// <summary>
        /// Ship class Engine statistics.
        /// </summary>
        [DisplayName("Max Engine Power"),
        Category("Engine Stats"),
        Description("The maximum power of this ships engines"),
        Browsable(true),
        ReadOnly(true)]
        public int MaxEnginePower { get; set; }

        [DisplayName("Max Thermal Signature"),
        Category("Engine Stats"),
        Description("The maximum Thermal Signature generated by this ships engines"),
        Browsable(true),
        ReadOnly(true)]
        public int MaxThermalSignature { get; set; }

        [DisplayName("Max Speed"),
        Category("Engine Stats"),
        Description("the Maximum speed of this ship"),
        Browsable(true),
        ReadOnly(true)]
        public int MaxSpeed { get; set; }

        /// <summary>
        /// List of passive sensor types, and how many of each that there are in this ship.
        /// Likewise the best possible sensors are stored.
        /// </summary>
        [DisplayName("Passive Sensors"), 
        Category("Component Lists"),
        Description("List of passive sensors on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<PassiveSensorDefTN> ShipPSensorDef { get; set; }

        [DisplayName("Passive Sensors Count"), 
        Category("Component Counts"),
        Description("Number of passive sensors on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<ushort> ShipPSensorCount { get; set; }

        [DisplayName("Best Thermal Rating"), 
        Category("Detials"),
        Description("Best Thermal Rating that can be detected by this ships passive sensors."),
        Browsable(true),
        ReadOnly(true)]
        public int BestThermalRating { get; set; }

        [DisplayName("Best EM Rating"), 
        Category("Detials"),
        Description("Best EM Rating that can be detected by this ships passive sensors."),
        Browsable(true),
        ReadOnly(true)]
        public int BestEMRating { get; set; }

        /// <summary>
        /// List of active sensors, as well as the number of each, and the TCS and EM signatures of the craft.
        /// </summary>
        [DisplayName("Active Sensors"), 
        Category("Component Lists"),
        Description("List of active sensors on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<ActiveSensorDefTN> ShipASensorDef { get; set; }

        [DisplayName("Active Sensors Count"), 
        Category("Component Counts"),
        Description("Number of active sensors on this ship."),
        Browsable(true),
        ReadOnly(true)]
        public BindingList<ushort> ShipASensorCount { get; set; }

        [DisplayName("Cross Cection"), 
        Category("Detials"),
        Description("Total Cross Section of this Class."),
        Browsable(true),
        ReadOnly(true)]
        public int TotalCrossSection { get; set; }

        [DisplayName("Max EM Signature"), 
        Category("Detials"),
        Description("Max EM Signature of this class.."),
        Browsable(true),
        ReadOnly(true)]
        public int MaxEMSignature { get; set; }


        /// <summary>
        /// This constructor will initialize the craft class to a default conventional armored 0 space ship, with a deployment time of 3 months and a name of title.
        /// </summary>
        /// <param name="Title">Class name</param>
        public ShipClassTN(string Title)
        {
            Name = Title;

            ShipsInClass = new BindingList<ShipTN>();

            /// <summary>
            /// Sanity initializations
            /// </summary>
            BuildPointCost = 0.0m;
            SizeHS = 0.0f;
            SizeTons = 0.0f;
            TotalHTK = 0;
            IsMilitary = false;
            MilitaryComponentCount = 0;
            PlanetaryProtectionValue = 0;

            ShipArmorDef = new ArmorDefTN("Conventional Armor");
            NewArmor("Conventional Armor", 2, 1);

            CrewQuarters = new BindingList<GeneralComponentDefTN>();
            CrewQuartersCount = new BindingList<ushort>();
            TotalCrewQuarters = 0;
            TotalRequiredCrew = 0;
            SpareCrewQuarters = 0;
            SpareCryoBerths = 0;
            MaxDeploymentTime = 3;
            TonsPerMan = (float)Math.Pow((double)MaxDeploymentTime, (1.0 / 3.0));
            CapPerHS = 50.0f / TonsPerMan;
            AccomHSRequirement = 0.0f;
            AccomHSAvailable = 0.0f;

            FuelTanks = new BindingList<GeneralComponentDefTN>();
            FuelTanksCount = new BindingList<ushort>();
            TotalFuelCapacity = 0.0f;

            EngineeringBays = new BindingList<GeneralComponentDefTN>();
            EngineeringBaysCount = new BindingList<ushort>();
            TotalMSPCapacity = 0;
            EngineeringHS = 0.0f;
            MaintenanceLife = 0.0f;
            AnnualFailureRate = 0.0f; 
            InitialFailureRate = 0.0f;
            YearOneFailureTotal = 0.0f;
            YearFiveFailureTotal = 0.0f;
            MaxDamageControlRating = 0;
            MaxRepair = 0;

            OtherComponents = new BindingList<GeneralComponentDefTN>();
            OtherComponentsCount = new BindingList<ushort>();
            HasBridge = false;


            MaxFuelUsePerHour = 0.0f;
            ShipEngineCount = 0;

            MaxEnginePower = 0;
            MaxThermalSignature = 0;
            MaxSpeed = 0;

            ShipPSensorDef = new BindingList<PassiveSensorDefTN>();
            ShipPSensorCount = new BindingList<ushort>();
            BestThermalRating = 1;
            BestEMRating = 1;

            ShipASensorDef = new BindingList<ActiveSensorDefTN>();
            ShipASensorCount = new BindingList<ushort>();
            TotalCrossSection = 0;
            MaxEMSignature = 0;
        }

        /// <summary>
        /// Sets deployment time and alters crew requirement statistics.
        /// </summary>
        /// <param name="months">Months of deployment tour.</param>
        public void SetDeploymentTime(int months)
        {
            MaxDeploymentTime = months;
            TonsPerMan = (float)Math.Pow((double)MaxDeploymentTime, (1.0 / 3.0));
            CapPerHS = 50.0f / TonsPerMan;
            AccomHSRequirement = (((float)TotalRequiredCrew * TonsPerMan) / 50.0f);
        }

        /// <summary>
        /// General Class update function, many things will change as a result of adding components, this function handles them all.
        /// I think this function might be enough to handle subtracting components as well. Update: now subtracting.
        /// </summary>
        /// <param name="CDTN">Basic abstract class definition of the added component.</param>
        /// <param name="increment">The number of new components to be added.</param>
        private void UpdateClass(ComponentDefTN Component, short increment )
        {

            /// <summary>
            /// Size of the craft has to be adjusted
            /// </summary>
            SizeHS = SizeHS + (Component.size * (float)increment);
            SizeTons = SizeHS * 50.0f;

            /// <summary>
            /// The ship has a new total required crew now.
            /// </summary>
            TotalRequiredCrew = TotalRequiredCrew + (Component.crew * increment);
            AccomHSRequirement = (((float)TotalRequiredCrew * TonsPerMan) / 50.0f);

            /// <summary>
            /// The Cost of the ship has likewise gone up.
            /// </summary>
            BuildPointCost = BuildPointCost + (Component.cost * increment);

            /// <summary>
            /// Update TotalHTK
            /// </summary>
            TotalHTK = TotalHTK + (Component.htk * increment);

            /// <summary>
            /// Update Military status. Does this craft suffer maintenance failures?
            /// </summary>
            if (Component.isMilitary == true)
            {
                MilitaryComponentCount = MilitaryComponentCount + increment;

                if (MilitaryComponentCount > 0)
                    IsMilitary = true;
            }

            /// <summary>
            /// Armor requires that size and cost be subtracted from the ship before recalculation/readding.
            /// </summary>
            BuildPointCost = BuildPointCost - ShipArmorDef.cost;
            SizeHS = SizeHS - ShipArmorDef.size;

            ShipArmorDef.CalcArmor(ShipArmorDef.name, ShipArmorDef.armorPerHS, SizeHS, ShipArmorDef.depth);

            BuildPointCost = BuildPointCost + ShipArmorDef.cost;
            SizeHS = SizeHS + ShipArmorDef.size;

            /// <summary>
            /// Due to the change in size the cross section will be different.
            /// </summary>
            TotalCrossSection = (int)Math.Ceiling(SizeHS);

            /// <summary>
            /// Likewise speed shall change.
            /// </summary>
            MaxSpeed = (int)((1000.0f / (float)TotalCrossSection) * (float)MaxEnginePower);

            /// <summary>
            /// MSP capacity and later maintenance will change. ***The rest of maintenance is not yet finished***.
            /// </summary>
            float EngPercent = SizeHS / EngineeringHS;
            TotalMSPCapacity = (int)((float)BuildPointCost * (EngPercent / 8.0f));

            /// <summary>
            /// Max repair can change.
            /// </summary>
            if (Component.cost > MaxRepair && increment >= 1)
            {
                MaxRepair = (int)Component.cost;
            }
            else
            {
                //***list through the components to find the next biggest one.***
            }
        }

        /// <summary>
        /// NewArmor updates the ships existing armor in the specified manner:
        /// </summary>
        /// <param name="Title">New Name of armor.</param>
        /// <param name="ArmorPHS">New armor type, conventional to collapsium in int form.</param>
        /// <param name="ArmorDepth">New depth of armor coverage.</param>
        public void NewArmor(string Title, ushort ArmorPHS, ushort ArmorDepth)
        {
            /// <summary>
            /// Armor requires that size and cost be subtracted from the ship before recalculation/readding.
            /// </summary>
            BuildPointCost = BuildPointCost - ShipArmorDef.cost;
            SizeHS = SizeHS - ShipArmorDef.size;

            ShipArmorDef.CalcArmor(Title, ArmorPHS, SizeHS, ArmorDepth);

            BuildPointCost = BuildPointCost + ShipArmorDef.cost;
            SizeHS = SizeHS + ShipArmorDef.size;
        }

        /// <summary>
        /// Adds the specified crew quarter component to the ship. Subtracts now.
        /// </summary>
        /// <param name="CrewQ">General Component Crew Quarter definition.</param>
        /// <param name="inc">Number of crew quarters to add, or subtract.</param>
        public void AddCrewQuarters(GeneralComponentDefTN CrewQ, short inc)
        {
            /// <summary>
            /// Wrong type of generalComponent def sent to add crew quarters. What error should be sent?
            /// </summary>
            if (CrewQ.componentType != GeneralType.Crew)
            {
                return;
            }

            int CrewIndex = CrewQuarters.IndexOf(CrewQ);
            if (CrewIndex != -1)
            {
                CrewQuartersCount[CrewIndex] = (ushort)(CrewQuartersCount[CrewIndex] + (ushort)inc);
            }
            else if (CrewIndex == -1 && inc >= 1)
            {
                CrewQuarters.Add(CrewQ);
                CrewQuartersCount.Add((ushort)inc);
            }
            else
            {
                if (CrewIndex != -1)
                {
                    if (CrewQuartersCount[CrewIndex] == 0)
                    {
                        CrewQuartersCount.RemoveAt(CrewIndex);
                        CrewQuarters.RemoveAt(CrewIndex);
                    }
                }
                else
                {
                    /// <summary>
                    /// Perhaps some kind of error should be noted here.
                    /// </summary>
                    return;
                }
            }

            /// <summary>
            /// The Size of the available accomodations for crew is increased by the size of this component.
            /// </summary>
            AccomHSAvailable = AccomHSAvailable + (CrewQ.size * (float)inc);

            /// <summary>
            /// Total Crew Berths. AccomHS / Tons per man.
            /// </summary>
            TotalCrewQuarters = (int)Math.Floor(AccomHSAvailable / TonsPerMan);

            /// <summary>
            /// General Housekeeping
            /// </summary>
            UpdateClass(CrewQ, inc);
        }

        /// <summary>
        /// Adds the specified Fuel Tanks to the ship. Subtracts now.
        /// </summary>
        /// <param name="FuelT">Fuel tank definition</param>
        /// <param name="inc">number of fuel tanks.</param>
        public void AddFuelStorage(GeneralComponentDefTN FuelT, short inc)
        {
            /// <summary>
            /// Wrong type of generalComponent def sent to add Fuel Storage.
            /// </summary>
            if (FuelT.componentType != GeneralType.Fuel)
            {
                return;
            }

            int FuelIndex = FuelTanks.IndexOf(FuelT);
            if (FuelIndex != -1)
            {
                FuelTanksCount[FuelIndex] = (ushort)(FuelTanksCount[FuelIndex] + (ushort)inc);
            }
            if (FuelIndex == -1 && inc >= 1)
            {
                FuelTanks.Add(FuelT);
                FuelTanksCount.Add((ushort)inc);
            }
            else
            {
                if (FuelIndex != -1)
                {
                    if (FuelTanksCount[FuelIndex] == 0)
                    {
                        FuelTanksCount.RemoveAt(FuelIndex);
                        FuelTanks.RemoveAt(FuelIndex);
                    }
                }
                else
                {
                    /// <summary>
                    /// Perhaps some kind of error should be noted here.
                    /// </summary>
                    return;
                }
            }

            TotalFuelCapacity = TotalFuelCapacity + (FuelT.size * (float)inc * 50000.0f);

            UpdateClass(FuelT, inc);
        }

        /// <summary>
        /// Adds engineering bays to the design. subtracts now.
        /// </summary>
        /// <param name="EBay">Component definition.</param>
        /// <param name="inc">Number of components.</param>
        public void AddEngineeringSpaces(GeneralComponentDefTN EBay, byte inc)
        {
            /// <summary>
            /// Wrong type of generalComponent def sent to add Engineering Spaces.
            /// </summary>
            if (EBay.componentType != GeneralType.Engineering)
            {
                return;
            }

            int EBayIndex = EngineeringBays.IndexOf(EBay);

            if (EBayIndex != -1)
            {
                EngineeringBaysCount[EBayIndex] = (ushort)(EngineeringBaysCount[EBayIndex] + (ushort)inc);
            }

            if (EBayIndex == 1 && inc >= 1)
            {
                EngineeringBays.Add(EBay);
                EngineeringBaysCount.Add(inc);
            }
            else
            {
                if (EBayIndex != -1)
                {
                    if (EngineeringBaysCount[EBayIndex] == 0)
                    {
                        EngineeringBaysCount.RemoveAt(EBayIndex);
                        EngineeringBays.RemoveAt(EBayIndex);
                    }
                }
                else
                {
                    /// <summary>
                    /// Error message?
                    /// </summary>
                    return;
                }
            }

            EngineeringHS = EngineeringHS + (EBay.size * (float)inc);

            UpdateClass(EBay, inc);
        }

        /// <summary>
        /// AddOtherComponent handles specialty general components. To Subtract add a negative number of the component.
        /// </summary>
        /// <param name="Other">The Component Definition.</param>
        /// <param name="inc">The number of components.</param>
        public void AddOtherComponent(GeneralComponentDefTN Other, short inc)
        {
            /// <summary>
            /// Wrong type of generalComponent def sent to add Other Component.
            /// </summary>
            if (Other.componentType < GeneralType.Bridge)
            {
                return;
            }

            int OtherCompIndex = OtherComponents.IndexOf(Other);
            if (OtherCompIndex != -1)
            {
                OtherComponentsCount[OtherCompIndex] = (ushort)(OtherComponentsCount[OtherCompIndex] + (ushort)inc);
            }
            if (OtherCompIndex == -1 && inc >= 1)
            {
                OtherComponents.Add(Other);
                OtherComponentsCount.Add((ushort)inc);
            }
            else
            {
                if (OtherCompIndex != -1)
                {
                    if (OtherComponentsCount[OtherCompIndex] == 0)
                    {
                        OtherComponentsCount.RemoveAt(OtherCompIndex);
                        OtherComponents.RemoveAt(OtherCompIndex);
                    }

                }
                else
                {
                    /// <summary>
                    /// Error here so return.
                    /// </summary>
                    return;
                }
            }

            if (Other.componentType == GeneralType.Bridge)
            {
                HasBridge = true;

                //***Fill in the rest of this if statement for other components, and subtracting components.
            }

            UpdateClass(Other, inc);
        }

        /// <summary>
        /// Right now all this function does is overwrite the previous engine entry if switching types.
        /// I think I'll add a static variable to ComponentDefTN to deal with that. Can subtract.
        /// </summary>
        /// <param name="Engine">Engine Definition</param>
        /// <param name="inc">Number of engines to be added.</param>
        public void AddEngine(EngineDefTN Engine, short inc)
        {
            ShipEngineDef = Engine;
            ShipEngineCount = (ushort)(ShipEngineCount + (ushort)inc);

            MaxEnginePower = MaxEnginePower + (int)(Engine.enginePower * (ushort)inc);
            MaxThermalSignature = MaxThermalSignature + (int)(Engine.thermalSignature * (ushort)inc);
            MaxFuelUsePerHour = MaxFuelUsePerHour + (Engine.fuelUsePerHour * (float)inc);

            UpdateClass(Engine, inc);
        }

        /// <summary>
        /// AddPassiveSensor adds the specified sensor in quantity inc. Can subtract.
        /// </summary>
        /// <param name="Sensor">Passive sensor definition</param>
        /// <param name="inc">Number of sensors to add.</param>
        public void AddPassiveSensor(PassiveSensorDefTN Sensor, short inc)
        {
            int SensorIndex = ShipPSensorDef.IndexOf(Sensor);
            if (SensorIndex != -1)
            {
                ShipPSensorCount[SensorIndex] = (ushort)(ShipPSensorCount[SensorIndex] + (ushort)inc);
            }
            if (SensorIndex == -1 && inc >= 1)
            {
                ShipPSensorDef.Add(Sensor);
                ShipPSensorCount.Add((ushort)inc);
            }
            else
            {
                if (SensorIndex != -1)
                {
                    if (ShipPSensorCount[SensorIndex] == 0)
                    {
                        ShipPSensorCount.RemoveAt(SensorIndex);
                        ShipPSensorDef.RemoveAt(SensorIndex);
                    }
                }
                else
                {
                    /// <summary>
                    /// Error here so return.
                    /// </summary>
                    return;
                }
            }

            if (Sensor.thermalOrEM == PassiveSensorType.Thermal)
            {
                if (Sensor.rating > BestThermalRating)
                {
                    BestThermalRating = (int)Sensor.rating;
                }
            }
            else if (Sensor.thermalOrEM == PassiveSensorType.EM)
            {
                if (Sensor.rating > BestEMRating)
                {
                    BestEMRating = (int)Sensor.rating;
                }
            }

            UpdateClass(Sensor, inc);
        }

        /// <summary>
        /// AddActiveSensor adds the specified sensor in quantity inc. Can Subtract.
        /// </summary>
        /// <param name="Sensor">Active sensor definition</param>
        /// <param name="inc">Number of sensors to add.</param>
        public void AddActiveSensor(ActiveSensorDefTN Sensor, byte inc)
        {
            int SensorIndex = ShipASensorDef.IndexOf(Sensor);
            if (SensorIndex != -1)
            {
                ShipASensorCount[SensorIndex] = (ushort)(ShipASensorCount[SensorIndex] + (ushort)inc);
            }
            if (SensorIndex == -1 && inc >= 1)
            {
                ShipASensorDef.Add(Sensor);
                ShipASensorCount.Add((ushort)inc);
            }
            else
            {
                if (SensorIndex != -1)
                {
                    if (ShipASensorCount[SensorIndex] == 0)
                    {
                        ShipASensorCount.RemoveAt(SensorIndex);
                        ShipASensorDef.RemoveAt(SensorIndex);
                    }
                }
                else
                {
                    /// <summary>
                    /// Error here so return.
                    /// </summary>
                    return;
                }
            }

            MaxEMSignature = MaxEMSignature + (Sensor.gps * (int)inc);

            UpdateClass(Sensor, inc);
        }
    }
}
