using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;

namespace fundamentals.tutorial.PatternMatchingForDataAndTypeDrivenAlgorithms;


/*
 
 This tutorial demonstrates the power and utility of pattern matching in C# for scenarios involving
diverse data types and varying requirements. Here's a succinct summary of the key points:

Why Use Pattern Matching: Pattern matching allows you to write functionality that can differentiate
and respond to different data types and shapes. This is particularly useful when working with types from
multiple data sources that don't necessarily fit into a cohesive object hierarchy in your application.

Scenarios for Pattern Matching:

- You may be dealing with types from different systems without a common base class.
- The operation you need to perform isn't inherent to the type itself. For instance,
  calculating tolls for different vehicle types based on external rules.
- Pattern Matching Designs: Pattern matching proves beneficial when:

- The data types don't follow an object hierarchy aligned with your requirements.
- The desired functionality isn't a core characteristic of those data types.
- Types of Patterns:

- Declaration Pattern: Matches data types and can cast them.
- Property Pattern: Matches data types based on their property values.
- Recursive Patterns: Combines other patterns, like using a constant pattern inside a property pattern.
- Switch Expressions: Offers a more concise way than switch statements to handle multiple patterns.
- Nested Switches: For better clarity and less repetition, you can nest switch expressions within each other.

 
 */

public class TollCalculator
{

    public decimal CalculateToll(object vehicle) =>
    vehicle switch
    {
        Car { Passengers: 0 } => 2.00m + 0.50m,
        Car { Passengers: 1 } => 2.0m,
        Car { Passengers: 2 } => 2.0m - 0.50m,
        Car => 2.00m - 1.0m,

        Taxi { Fares: 0 } => 3.50m + 1.00m,
        Taxi { Fares: 1 } => 3.50m,
        Taxi { Fares: 2 } => 3.50m - 0.50m,
        Taxi => 3.50m - 1.00m,

        Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
        Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
        Bus => 5.00m,

        DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
        DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
        DeliveryTruck => 10.00m,

        { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
        null => throw new ArgumentNullException(nameof(vehicle))
    };




    public decimal CalculateTollNestedSwitches(object vehicle) =>
    vehicle switch
    {
        Car c => c.Passengers switch
        {
            0 => 2.00m + 0.5m,
            1 => 2.0m,
            2 => 2.0m - 0.5m,
            _ => 2.00m - 1.0m
        },

        Taxi t => t.Fares switch
        {
            0 => 3.50m + 1.00m,
            1 => 3.50m,
            2 => 3.50m - 0.50m,
            _ => 3.50m - 1.00m
        },

        Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
        Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
        Bus b => 5.00m,

        DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
        DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
        DeliveryTruck t => 10.00m,

        { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
        null => throw new ArgumentNullException(nameof(vehicle))
    };
}



