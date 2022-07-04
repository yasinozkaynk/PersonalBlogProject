using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofaceBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>().SingleInstance();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>().SingleInstance();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>().SingleInstance();

            builder.RegisterType<ToDoListManager>().As<IToDoListService>().SingleInstance();
            builder.RegisterType<EfToDoListDal>().As<IToDoListDal>().SingleInstance();

            builder.RegisterType<WriterMessageManager>().As<IWriterMessageService>().SingleInstance();
            builder.RegisterType<EfWriterMessageDal>().As<IWriterMessageDal>().SingleInstance();

            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().SingleInstance();

            builder.RegisterType<WriterUserManager>().As<IWriterUserService>().SingleInstance();
            builder.RegisterType<EfWriterUserDal>().As<IWriterUserDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            //builder.RegisterType<BlogCommentManager>().As<IBlogCommentService>().SingleInstance();
            //builder.RegisterType<EfBlogCommentDal>().As<IBlogCommentDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
