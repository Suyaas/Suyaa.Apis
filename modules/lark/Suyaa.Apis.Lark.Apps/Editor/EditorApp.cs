﻿using Suyaa.Apis.Lark.Apps.Editor.Stos;
using Suyaa.Apis.Lark.Cores.Editor;
using Suyaa.Apis.Services.ApiManager;
using Suyaa.Microservice.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Lark.Apps.Editor
{
    /// <summary>
    /// 编辑器
    /// </summary>
    [App("Lark/Editor")]
    public class EditorApp : ServiceApp
    {
        private readonly IEditorCore _editorCore;

        /// <summary>
        /// 编辑器
        /// </summary>
        public EditorApp(
            IEditorCore editorCore
            )
        {
            _editorCore = editorCore;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [Get]
        public async Task<string> Get(string path)
        {
            return await _editorCore.GetFileContent(path);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Post]
        public async Task Save(EditorSaveInput input)
        {

        }
    }
}
