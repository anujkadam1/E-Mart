using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics.Contracts;
using System.Net.NetworkInformation;
using System;

using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using E_Mart.Models;



namespace E_Mart.DAO.Interfaces
{
    public interface IGrocceryRepository
    {
        Task<IEnumerable<Groccery>> GetAllGrocceriesAsync();
        Task<Groccery> GetGrocceryByIdAsync(int id);
        Task<bool> AddGrocceryAsync(Groccery groccery);
        Task UpdateGrocceryAsync(Groccery groccery);
        Task DeleteGrocceryAsync(int id);
    }
}





