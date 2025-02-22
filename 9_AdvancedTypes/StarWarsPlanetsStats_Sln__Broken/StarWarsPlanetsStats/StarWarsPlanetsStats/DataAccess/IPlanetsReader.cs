﻿using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.DataAccess;

    public interface IPlanetsReader
    {
        Task<IEnumerable<Planet>> Read(string baseAddress, string requestUri);
    }

