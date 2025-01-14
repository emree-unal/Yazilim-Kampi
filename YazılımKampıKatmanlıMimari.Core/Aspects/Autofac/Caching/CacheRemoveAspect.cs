﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using YazılımKampıKatmanlıMimari.Core.CrossCuttingConcerns.Caching;
using YazılımKampıKatmanlıMimari.Core.Utilities.Interceptors;
using YazılımKampıKatmanlıMimari.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
namespace YazılımKampıKatmanlıMimari.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
