﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();   

            builder.RegisterType<RentManager>().As<IRentService>().SingleInstance();
            builder.RegisterType<EfRentDal>().As<IRentDal>().SingleInstance();

            builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();
            builder.RegisterType<EfImageDal>().As<IImageDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
