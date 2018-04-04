using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Diagnostics;
using Microsoft.Web.Administration;

namespace IISHelper
{
    class IISManager
    {
        public string IISVersion { get; set; }
        public string ServerName { get; set; }

        public ServerManager _ServerManager
        {
            get
            {
                return _serverMngr;
            }

            set
            {
                _serverMngr = value;
            }
        }

        ServerManager _serverMngr;

        public IISManager()
        {
            _ServerManager = new ServerManager();
        }

        public IISManager(string serverName)
        {
            _ServerManager = ServerManager.OpenRemote(serverName);
        }

        public List<IISSite> GetSiteNames()
        {
            List<IISSite> sites = new List<IISSite>();

            foreach (var site in _ServerManager.Sites)
            {
                IISSite item = new IISSite();
                item.Id = site.Id;
                item.Name = site.Name;
                item.State = Convert.ToString(site.State);
                item.AppCount = site.Applications.Count();
                item.BindingCount = site.Bindings.Count();
                sites.Add(item);
            }

            return sites;
        }

        public List<IISApplication> GetApplications(string site)
        {
            List<IISApplication> apps = new List<IISApplication>();

            Site foundSite = GetSite(site);
            foreach (var app in foundSite.Applications)
            {
                IISApplication item = new IISApplication();
                item.Site = foundSite.Name;
                item.Name = app.Path;
                item.Pool = app.ApplicationPoolName;
                item.State = Convert.ToString(foundSite.State);
                item.Path = app.VirtualDirectories[0].PhysicalPath;
                apps.Add(item);
            }
            return apps;
        }

        public List<IISPool> GetPools()
        {
            List<IISPool> pools = new List<IISPool>();

            foreach (var item in _ServerManager.ApplicationPools)
            {
                IISPool pool = new IISPool();
                pool.Name = item.Name;
                pool.Mode = item.ManagedPipelineMode.ToString();
                pool.Version = item.ManagedRuntimeVersion;
                pool.State = item.State.ToString();
                pools.Add(pool);
            }

            return pools;
        }

        public string GetPool(string siteName, string appName)
        {
            Site site = _ServerManager.Sites[siteName];
            return site.Applications[appName].ApplicationPoolName;
        }

        public string GetSitePool(string siteName)
        {
            Site site = _ServerManager.Sites[siteName];
            return site.Applications[0].ApplicationPoolName;
        }

        public List<IISBinding> GetBindings(string siteName)
        {
            Site site = _ServerManager.Sites[siteName];
            List<IISBinding> bindings = new List<IISBinding>();

            foreach (Binding binding in site.Bindings)
            {
                IISBinding isb = new IISBinding();
                isb.Binding = binding.BindingInformation;
                isb.Protocol = binding.Protocol;
                isb.Name = binding.Host;
                bindings.Add(isb);
            }

            return bindings;
        }

        public List<Certificate> GetCertificates(string siteName)
        {
            Site site = _ServerManager.Sites[siteName];
            List<Certificate> certs = new List<Certificate>();

            try
            {

                foreach (Binding binding in site.Bindings)
                {

                    if (binding.Protocol == "https")
                    {
                        Certificate c = new Certificate();
                        Certificate cert = GetCertByHashCode(binding.CertificateHash);
                        c.Name = cert.Name;
                        c.Site = siteName;
                        c.Issuer = cert.Issuer;
                        c.Store = cert.Store;
                        //c.Expire = cert.GetExpirationDateString();
                        c.Binding = binding.BindingInformation;
                        c.Protocol = binding.Protocol;
                        // c.Subject = cert.SubjectName.Name.
                        certs.Add(c);
                    }
                    else
                    {
                        //Certificate c = new Certificate();
                        //string sBindingHostInfo = binding.BindingInformation.Substring(binding.BindingInformation.LastIndexOf(':') + 1);
                        //c.Name = binding.BindingInformation;
                        //c.Site = siteName;
                        //c.Store = binding.CertificateStoreName;
                        //c.Binding = binding.BindingInformation;
                        //c.Protocol = binding.Protocol;
                        //certs.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return certs;
        }

        public Certificate GetCertByHashCode(byte[] certHash)
        {
            List<Certificate> storeCerts = GetMyStoreCerts();
            Certificate foundCert = null;

            foreach (Certificate mCert in storeCerts)
            {
                if (certHash.SequenceEqual(mCert.Hash))
                {
                    return mCert;
                }
            }

            return foundCert;
        }
        public static X509Certificate2 GetCertificate(string clientCertName)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, "CN=" + clientCertName, false);

            if (certificates.Count == 0)
            {
                throw new Exception("Certificate not found for name " + clientCertName);
            }
            else
            {
                return certificates[0];
            }
        }

        private Site GetSite(string site)
        {
            Site foundSite = _ServerManager.Sites.Where(x => x.Name == site).FirstOrDefault();
            return foundSite;
        }

        public bool StopPool(string pool)
        {
            bool stopped = false;

            ApplicationPool currentPool = _ServerManager.ApplicationPools[pool];
            currentPool.Stop();
            if (currentPool.State == ObjectState.Stopped)
                stopped = true;

            return stopped;
        }

        public bool StartPool(string pool)
        {
            bool started = false;

            ApplicationPool currentPool = _ServerManager.ApplicationPools[pool];
            currentPool.Start();
            if (currentPool.State == ObjectState.Started)
                started = true;

            return started;
        }

        public bool RecyclePool(string pool)
        {
            bool recycled = false;

            ApplicationPool currentPool = _ServerManager.ApplicationPools[pool];
            if (currentPool.State == ObjectState.Started)
            {
                currentPool.Recycle();
                recycled = true;
            }

            return recycled;
        }

        public bool StopSite(string site)
        {
            bool stopped = false;
            Site iissite = _ServerManager.Sites[site];
            if (iissite.State != ObjectState.Stopped)
            {
                iissite.Stop();
                if (iissite.State == ObjectState.Stopped)
                    stopped = true;
            }

            return stopped;
        }

        public bool StartSite(string site)
        {
            bool started = false;
            Site iissite = _ServerManager.Sites[site];
            if (iissite.State != ObjectState.Started)
            {
                iissite.Start();
                if (iissite.State == ObjectState.Started)
                    started = true;
            }

            return started;
        }

        public bool RestartSite(string site)
        {
            bool restarted = false;
            Site iissite = _ServerManager.Sites[site];
            iissite.Stop();
            iissite.Start();
            restarted = true;
            return restarted;
        }

        public bool DeleteSite(string site)
        {
            try
            {
                Site iissite = _ServerManager.Sites[site];
                _ServerManager.Sites.Remove(iissite);
                _ServerManager.CommitChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;

            }

            return false;
        }

        public bool DeleteApp(string site, string app)
        {
            try
            {
                Site iissite = _ServerManager.Sites[site];
                _ServerManager.Sites[site].Applications.Remove(iissite.Applications.FirstOrDefault(x => x.Path.Contains(app)));
                _ServerManager.CommitChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;

            }

            return false;
        }

        public void CreateApplicationPool(string applicationPoolName)
        {
            if (_ServerManager.ApplicationPools[applicationPoolName] != null)
                return;
            ApplicationPool newPool = _ServerManager.ApplicationPools.Add(applicationPoolName);
            newPool.ManagedRuntimeVersion = "v4.0";
            _ServerManager.CommitChanges();
        }

        public List<Certificate> GetMyStoreCerts()
        {
            List<Certificate> certs = new List<Certificate>();
            try
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);

                for (int i = 0; i < store.Certificates.Count; i++)
                {
                    Certificate cert = new Certificate();
                    cert.Name = store.Certificates[i].FriendlyName;
                    cert.Issuer = store.Certificates[i].Issuer;
                    cert.Subject = store.Certificates[i].Subject;
                    cert.Expire = store.Certificates[i].NotAfter.ToShortDateString();
                    cert.Store = store.Name;
                    cert.Hash = store.Certificates[i].GetCertHash();
                    certs.Add(cert);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return certs;
        }

        private X509Certificate2 FindIisHttpsCert(string sWebsite)
        {
            Site yourSite = _ServerManager.Sites[sWebsite];

            X509Certificate2 yourCertificate = null;

            foreach (Binding binding in yourSite.Bindings)
            {


                if (binding.Protocol == "https")
                {
                    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadOnly);
                    string bindHash = System.Convert.ToBase64String(binding.CertificateHash);
                    //yourCertificate = store.Certificates.Find(X509FindType.FindByThumbprint, System.Convert.ToBase64String(binding.CertificateHash), true)[0];
                    foreach (var cert in store.Certificates)
                    {
                        string certHash = System.Convert.ToBase64String(cert.GetCertHash());
                        if (bindHash == certHash)
                        {
                            return cert;
                        }

                    }

                }
            }

            return yourCertificate;
        }

        public bool CreateSite(string siteName, string path, string hostname, string pool)
        {
            bool created = false;
            if (_ServerManager.Sites != null && _ServerManager.Sites.Count > 0)
            {
                //we will first check to make sure that the site isn't already there
                if (_ServerManager.Sites.FirstOrDefault(s => s.Name == siteName) == null)
                {
                    ServerManager iisManager = new ServerManager();
                    iisManager.Sites.Add(siteName, "http", "*:80:" + hostname, path);
                    iisManager.Sites[siteName].ApplicationDefaults.ApplicationPoolName = pool;

                    foreach (var item in iisManager.Sites[siteName].Applications)
                    {
                        item.ApplicationPoolName = pool;
                    }

                    iisManager.CommitChanges();
                    created = true;
                }
            }

            return created;
        }

        public void CreateApplication(string siteName, string applicationName, string path, string appPool = "")
        {
            var site = _ServerManager.Sites.Where(x => x.Name == siteName).FirstOrDefault();
            var applications = site.Applications;

            if (applications["/" + applicationName] == null)
            {
                applications.Add("/" + applicationName, path);
                _ServerManager.CommitChanges();
            }

            if (appPool != string.Empty)
                SetApplicationApplicationPool(siteName, applicationName, appPool);
        }

        //public static void CreateVirtualDirectory(string siteName, string applicationName, string virtualDirectoryName, string path)
        //{
        //    using (ServerManager serverManager = new ServerManager())
        //    {
        //        var application = GetApplication(serverManager, siteName, applicationName);
        //        application.VirtualDirectories.Add("/" + virtualDirectoryName, path);
        //        serverManager.CommitChanges();
        //    }
        //}

        public void SetSiteAppsApplicationPool(string siteName, string applicationPoolName)
        {
            var site = _ServerManager.Sites.Where(x => x.Name == siteName).FirstOrDefault();
            if (site != null)
            {
                foreach (Application app in site.Applications)
                {
                    app.ApplicationPoolName = applicationPoolName;
                }
            }
            _ServerManager.CommitChanges();
        }

        public void SetApplicationApplicationPool(string siteName, string applicationName, string applicationPoolName)
        {
            var site = _ServerManager.Sites.Where(x => x.Name == siteName).FirstOrDefault();
            if (site != null)
            {
                foreach (Application app in site.Applications)
                {
                    if (app.Path.Contains(applicationName))
                        app.ApplicationPoolName = applicationPoolName;
                }
            }
            _ServerManager.CommitChanges();
        }

        public static string GetIISVersion()
        {
            string w3wpPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"inetsrv\w3wp.exe");
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(w3wpPath);
            return versionInfo.FileVersion;
        }

    }
}
