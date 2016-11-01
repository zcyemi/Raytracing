﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Sphere : Primitive
    {
        private float radius;
        private Vector3 center;

        public Sphere(Vector3 v, float radius)
        {
            center = v;
            this.radius = radius;
        }

        public override IntersectResult Intersect(Ray ray)
        {
            Vector3 centerRay = center - ray.origin;
            float centerDist = centerRay.length;
            if (centerDist < radius) return new IntersectResult();
            float cosa = centerRay.Dot(ray.dir) / centerDist;
            if (cosa < 0) return new IntersectResult();
            float sina =(float)Math.Sqrt((float)(1f - cosa * cosa));
            float lined = centerDist * sina;
            if (lined > radius) return new IntersectResult();
            float linecut = (float)Math.Sqrt(radius * radius - lined * lined);
            float dist = centerDist * cosa;
            float fdist = dist - linecut;
            Vector3 cutpos = ray.Pos(fdist);
            Vector3 nor = cutpos - center;
            return new IntersectResult(this, cutpos, nor.Nor(), fdist);
        }
    }
}
