﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using Xrm.Framework.CI.Common;

namespace Xrm.Framework.CI.Common.UnitTests
{
    [TestClass]
    public class SolutionManagerTest
    {
        private const string ImportResultsXml = @"
<importexportxml start=""636964156226630101"" stop=""636964156300230328"" progress=""14.8387096774194"" processed=""true"">
    <solutionManifests>
        <solutionManifest languagecode = ""1033"" id=""SolutionId"" LocalizedName=""Solution Name"" processed=""true"">
            <UniqueName>SolutionId</UniqueName>
            <LocalizedNames>
                <LocalizedName description = ""Solution Name"" languagecode=""1033"" />
            </LocalizedNames>
            <Descriptions>
                <Description description = ""NA"" languagecode=""1033"" />
            </Descriptions>
            <Version>2019.06.18.1</Version>
            <Managed>0</Managed>
            <Publisher>
                <UniqueName>new</UniqueName>
                <LocalizedNames>
                    <LocalizedName description = ""NEW"" languagecode=""1033"" />
                </LocalizedNames>
                <Descriptions />
                <EMailAddress />
                <SupportingWebsiteUrl />
                <Addresses>
                    <Address>
                        <City />
                        <Country />
                        <Line1 />
                        <Line2 />
                        <PostalCode />
                        <StateOrProvince />
                        <Telephone1 />
                    </Address>
                </Addresses>
            </Publisher>
            <results />
            <result result = ""failure"" errorcode=""0x8004801D"" errortext=""Solution manifest import: FAILURE: The following solution cannot be imported: SolutionId. Some dependencies are missing. The missing dependencies are : &lt;MissingDependencies&gt;&lt;MissingDependency&gt;&lt;Required key=&quot;521&quot; type=&quot;59&quot; schemaName=&quot;Account Locations&quot; displayName=&quot;Account Locations&quot; parentSchemaName=&quot;account&quot; parentDisplayName=&quot;Account&quot; solution=&quot;Active&quot; id=&quot;{00d41375-f98d-e911-a99a-000d3aa2c0c7}&quot; /&gt;&lt;Dependent key=&quot;500&quot; type=&quot;60&quot; displayName=&quot;Information&quot; parentDisplayName=&quot;Building&quot; id=&quot;{65e22d70-2665-475d-873d-e23bda6b232a}&quot; /&gt;&lt;/MissingDependency&gt;&lt;/MissingDependencies&gt; , ProductUpdatesOnly : False"" datetime=""00:47:09.76"" datetimeticks=""636964156297630395"">
                <parameters>
                    <parameter>SolutionId</parameter>
                    <parameter>&lt;MissingDependencies&gt;&lt;MissingDependency&gt;&lt;Required key=""521"" type=""59"" schemaName=""Account Locations"" displayName=""Account Locations"" parentSchemaName=""account"" parentDisplayName=""Account"" solution=""Active"" id=""{00d41375-f98d-e911-a99a-000d3aa2c0c7}"" /&gt;&lt;Dependent key=""500"" type=""60"" displayName=""Information"" parentDisplayName=""Building"" id=""{65e22d70-2665-475d-873d-e23bda6b232a}"" /&gt;&lt;/MissingDependency&gt;&lt;/MissingDependencies&gt;</parameter>
                    <parameter>False</parameter>
                </parameters>
            </result>
        </solutionManifest>
    </solutionManifests>
</importexportxml>
";

        [TestMethod]
        public void SolutionManager_VerifySolutionImport_PrettyPrintErrorMessage_Test()
        {
            var doc = new XmlDocument();
            doc.LoadXml(ImportResultsXml);

            var result = new SolutionImportResult();

            SolutionManager manager = new SolutionManager(new Logging.TestLogger(), null, null);

            manager.VerifySolutionImport_PrettyPrintErrorMessage(doc, result);

            Assert.IsNotNull(result.ErrorMessage);
        }
    }
}
