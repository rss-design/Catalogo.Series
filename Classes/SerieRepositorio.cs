using System;
using System.Collections.Generic;
using Catalogo.Series.Interfaces;

namespace Catalogo.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        // Lista de Series.
        private List<Serie> ListaSerie = new List<Serie>();

        // Implementações da Interface
        public void Atualiza(int id, Serie objeto)
        {
            ListaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
           ListaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}