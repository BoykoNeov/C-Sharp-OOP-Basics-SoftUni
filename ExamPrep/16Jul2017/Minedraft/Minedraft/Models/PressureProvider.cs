﻿public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput * 1.5)
    {
    }
}