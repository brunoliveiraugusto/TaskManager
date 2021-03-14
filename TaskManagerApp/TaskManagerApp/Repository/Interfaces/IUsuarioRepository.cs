﻿using System.Threading.Tasks;
using TaskManagerApp.Domain;

namespace TaskManagerApp.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task CriarUsuarioAsync(Usuario usuario);
        Task<bool> IndicaUsuarioExistenteAsync(string username);
    }
}