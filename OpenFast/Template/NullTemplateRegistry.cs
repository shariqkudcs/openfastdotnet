/*

The contents of this file are subject to the Mozilla Public License
Version 1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is OpenFAST.

The Initial Developer of the Original Code is The LaSalle Technology
Group, LLC.  Portions created by Shariq Muhammad
are Copyright (C) Shariq Muhammad. All Rights Reserved.

Contributor(s): Shariq Muhammad <shariq.muhammad@gmail.com>
                Yuri Astrakhan <FirstName><LastName>@gmail.com
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenFAST.Template
{
    internal sealed class NullTemplateRegistry : ITemplateRegistry
    {
        #region ITemplateRegistry Members

        public MessageTemplate[] Templates
        {
            get { return null; }
        }

        public bool TryGetTemplate(QName templateName, out MessageTemplate template)
        {
            template = null;
            return false;
        }

        public bool TryGetId(string name, out int templateId)
        {
            templateId = -1;
            return false;
        }

        public bool TryGetId(QName templateName, out int templateId)
        {
            templateId = -1;
            return false;
        }

        public bool TryGetId(MessageTemplate template, out int templateId)
        {
            templateId = -1;
            return false;
        }

        public event TemplateNotificationDelegate OnTemplateRegistered;

        public MessageTemplate this[int templateId]
        {
            get { return null; }
        }

        public MessageTemplate this[string templateName]
        {
            get { return null; }
        }

        public bool IsRegistered(string templateName)
        {
            return false;
        }

        public bool IsRegistered(int templateId)
        {
            return false;
        }

        public bool IsRegistered(MessageTemplate template)
        {
            return false;
        }

        public bool TryGetTemplate(int id, out MessageTemplate template)
        {
            template = null;
            return false;
        }

        public void Add(int templateId, MessageTemplate template)
        {
        }

        public void Remove(string name)
        {
        }

        public void Remove(MessageTemplate template)
        {
        }

        public void Remove(int templateId)
        {
        }

        public void Define(MessageTemplate template)
        {
        }

        public MessageTemplate this[QName templateName]
        {
            get { return null; }
        }

        public int GetId(string name)
        {
            return 0;
        }

        public int GetId(MessageTemplate template)
        {
            return 0;
        }

        public bool IsDefined(QName name)
        {
            return false;
        }

        public bool IsDefined(string name)
        {
            return false;
        }

        public bool TryGetTemplate(string name, out MessageTemplate template)
        {
            template = null;
            return false;
        }

        public void Add(int templateId, QName templateName)
        {
        }

        public bool TryAdd(int templateId, QName templateName)
        {
            return true;
        }

        public void Add(int templateId, string name)
        {
        }

        public int GetId(QName templateName)
        {
            return 0;
        }

        public bool IsRegistered(QName templateName)
        {
            return false;
        }

        public void Remove(QName templateName)
        {
        }

        public void RegisterAll(ITemplateRegistry registry)
        {
        }

        public ICollection<QName> Names()
        {
            return new QName[0];
        }

        #endregion

        public int GetTemplateId(string templateName)
        {
            return 0;
        }

        public int GetTemplateId(MessageTemplate template)
        {
            return 0;
        }

        public void Add(MessageTemplate template)
        {
        }

        public bool HasTemplate(string name)
        {
            return false;
        }

        public bool HasTemplate(QName name)
        {
            return false;
        }

        public bool HasTemplate(int id)
        {
            return false;
        }

        public bool IsDefined(MessageTemplate template)
        {
            return false;
        }

        public MessageTemplate[] ToArray()
        {
            return null;
        }

        public IEnumerator<KeyValuePair<int, MessageTemplate>> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}