﻿using SpeedyAir.Entities;

namespace SpeedyAir.Repositories;

public interface IFlightRepository
{
    List<Flight> GetFlights();
}