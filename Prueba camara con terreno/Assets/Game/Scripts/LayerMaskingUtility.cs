using UnityEngine;    public static class LayerMaskingUtility    {
        /// <summary>        /// Extension method to check if a layer is in a given layer mask.        /// </summary>        /// <param name="mask"></param>        /// <param name="layer"></param>        /// <returns></returns>        public static bool Contains(this LayerMask mask, int layer) => ((mask.value & (1 << layer)) != 0);    }
