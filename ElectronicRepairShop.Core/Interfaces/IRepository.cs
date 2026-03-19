using System;
using System.Collections.Generic;

namespace ElectronicRepairShop.Core.Interfaces;

/// <summary>
/// Базовый интерфейс для всех репозиториев системы
/// </summary>
/// <typeparam name="T"> тип сущности с которой работает репозиторий</typeparam>
public interface IRepository<T> where T : class
{
    T? GetById(Guid id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(Guid id);
}