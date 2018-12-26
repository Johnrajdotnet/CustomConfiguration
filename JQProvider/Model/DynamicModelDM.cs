using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQProvider.DataAcess.Models
{

    public class DynamicMutipleSetModel<T, K>
    {
        public List<K> DynamicListResultSetK { get; set; }
        public List<T> DynamicListResultSetT { get; set; }

    }
    public class DynamicMutipleSetModel<K, M, N>
    {
        public List<K> DynamicListResultSetK { get; set; }
        public List<M> DynamicListResultSetM { get; set; }
        public List<N> DynamicListResultSetN { get; set; }
    }
    public class DynamicMutipleSetModel<M, N, O, P, Q, R>
    {

        public List<M> DynamicListResultSetM { get; set; }
        public List<N> DynamicListResultSetN { get; set; }
        public List<O> DynamicListResultSetO { get; set; }
        public List<P> DynamicListResultSetP { get; set; }
        public List<Q> DynamicListResultSetQ { get; set; }
        public List<R> DynamicListResultSetR { get; set; }
    }

    public class DynamicMutipleModel<T, K>
    {
        public K DynamicResultK { get; set; }
        public T DynamicResultT { get; set; }
    }
    public class DynamicMutipleModel<K, M, N>
    {
        public K DynamicResultK { get; set; }
        public M DynamicResultM { get; set; }
        public N DynamicResultN { get; set; }
    }
    //public class DynamicMutipleSetModel<T,K>
    //{
    //    public List<T> DynamicListResultSetT { get; set; }
    //    public List<K> DynamicListResultSetK { get; set; }
    //}
    //public class DynamicMutipleSetModel<T, K,M>
    //{
    //    public List<T> DynamicListResultSetT { get; set; }
    //    public List<K> DynamicListResultSetK { get; set; }
    //    public List<M> DynamicListResultSetM { get; set; }
    //}
    //public class DynamicMutipleSetModel<T, K,M,N,O,P>
    //{
    //    public List<T> DynamicListResultSetT { get; set; }
    //    public List<K> DynamicListResultSetK { get; set; }

    //    public List<M> DynamicListResultSetM { get; set; }

    //    public List<N> DynamicListResultSetN { get; set; }
    //    public List<O> DynamicListResultSetO { get; set; }
    //    public List<P> DynamicListResultSetP { get; set; }
    //}

    //public class DynamicMutipleModel<T, K>
    //{
    //    public T DynamicResultT { get; set; }
    //    public K DynamicResultK { get; set; }


    //}
}
