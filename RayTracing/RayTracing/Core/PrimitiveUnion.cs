﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class PrimitiveUnion
    {
        public List<Primitive> primitives;


        private const float maxDist = 100000000;

        public PrimitiveUnion(List<Primitive> objs)
        {
            primitives = objs;
        }

        public IntersectResult Intersect(Ray ray)
        {
            float minDist = maxDist;
            IntersectResult finalResult = new IntersectResult();

            for(int i=0;i<primitives.Count;i++)
            {
                IntersectResult result = primitives[i].Intersect(ray);
                if(result.primitive != null && result.distance< minDist)
                {
                    minDist = result.distance;
                    finalResult = result;
                }
            }
            return finalResult;
        }
    }
}
