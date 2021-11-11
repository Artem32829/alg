using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class GraphVertexInfo
    {
        public GraphVertex Vertex { get; set; }

        
        /// Не посещенная вершина
        
        public bool IsUnvisited { get; set; }

       
        /// Сумма весов ребер
      
        public int EdgesWeightSum { get; set; }

       
        /// Предыдущая вершина
       
        public GraphVertex PreviousVertex { get; set; }

      
        /// Конструктор
     
        /// <param name="vertex">Вершина</param>
        public GraphVertexInfo(GraphVertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PreviousVertex = null;
        }
    }
}
