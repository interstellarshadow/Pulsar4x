﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Pulsar4X.Entities
{
    public class SpeciesGasConstraint : GameEntity
    {
        public Molecule Molecule { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}
