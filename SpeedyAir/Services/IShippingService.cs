﻿namespace SpeedyAir.Services;

public interface IShippingService
{
    string GetFlightSchedule();

    string GetOrderItineraries();
}