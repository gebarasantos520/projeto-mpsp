using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProjetoMPSP.API.ViewModel;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetoMPSP.API.Services
{
    public class ScrapingService
    {
        private readonly IWebDriver driver;
        private readonly IConfiguration _conf;

        public ScrapingService()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            driver = new ChromeDriver("Driver\\", chromeOptions);
        }

        public ScrapingService(IConfiguration conf)
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("--headless");
            driver = new ChromeDriver("Driver\\", chromeOptions);
            _conf = conf;
        }

        private string GetUrl(string system)
        {

            driver.Navigate().GoToUrl("http://ec2-18-231-116-58.sa-east-1.compute.amazonaws.com/login");
            driver.FindElement(By.Id("username")).SendKeys("fiap");
            driver.FindElement(By.Id("password")).SendKeys("mpsp");
            driver.FindElement(By.ClassName("btn-block")).Click();

            var links = driver.FindElements(By.XPath("//a[@href]")).ToList();

            foreach (var link in links)
            {
                if (link.Text == system)
                {
                    return link.GetAttribute("href");
                }
            }

            return null;
        }

        public bool AuthArisp()
        {
            try
            {
                var url = GetUrl("Arisp");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("//*[@id='btnCallLogin']")).Click();
                    driver.FindElement(By.Id("btnAutenticar")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthArisp(Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Arisp");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("//*[@id='btnCallLogin']")).Click();
                    driver.FindElement(By.Id("btnAutenticar")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }

        public bool AuthCadesp(string login, string senha)
        {
            try
            {
                var url = GetUrl("Cadesp");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_loginControl_UserName']")).SendKeys(login);
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_loginControl_Password']")).SendKeys(senha);
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_loginControl_loginButton']")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthCadesp(string login, string senha, Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Cadesp");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_loginControl_UserName']")).SendKeys(login);
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_loginControl_Password']")).SendKeys(senha);
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_loginControl_loginButton']")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }

        public bool AuthCaged(string cpf, string senha)
        {
            try
            {
                var url = GetUrl("Caged");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("//*[@id='username']")).SendKeys(cpf);
                    driver.FindElement(By.XPath("//*[@id='password']")).SendKeys(senha);
                    driver.FindElement(By.Id("btn-submit")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthCaged(string cpf, string senha, Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Caged");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("//*[@id='username']")).SendKeys(cpf);
                    driver.FindElement(By.XPath("//*[@id='password']")).SendKeys(senha);
                    driver.FindElement(By.Id("btn-submit")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }

        public bool AuthCensec(string login, string senha)
        {
            try
            {
                var url = GetUrl("Censec");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.Id("LoginTextBox")).SendKeys(login);
                    driver.FindElement(By.Id("SenhaTextBox")).SendKeys(senha);
                    driver.FindElement(By.XPath("//*[@id='EntrarButton']")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthCensec(string login, string senha, Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Censec");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.Id("LoginTextBox")).SendKeys(login);
                    driver.FindElement(By.Id("SenhaTextBox")).SendKeys(senha);
                    driver.FindElement(By.XPath("//*[@id='EntrarButton']")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }
        public bool AuthDetran(string login, string senha)
        {
            try
            {
                var url = GetUrl("Detran");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.Id("form:j_id563205015_44efc1ab")).SendKeys(login);
                    driver.FindElement(By.Id("form:j_id563205015_44efc191")).SendKeys(senha);
                    driver.FindElement(By.XPath("//*[@id='form:j_id563205015_44efc15b']")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthDetran(string login, string senha, Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Detran");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.Id("form:j_id563205015_44efc1ab")).SendKeys(login);
                    driver.FindElement(By.Id("form:j_id563205015_44efc191")).SendKeys(senha);
                    driver.FindElement(By.XPath("//*[@id='form:j_id563205015_44efc15b']")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }

        public bool AuthInfocrim(string login, string senha)
        {
            try
            {
                var url = GetUrl("Infocrim");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("/html/body/table/tbody/tr[3]/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]/td[3]/input")).SendKeys(login);
                    driver.FindElement(By.XPath("/html/body/table/tbody/tr[3]/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[2]/td[3]/input")).SendKeys(senha);
                    driver.FindElement(By.XPath("/html/body/table/tbody/tr[3]/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[2]/td[4]/a/img")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthInfocrim(string login, string senha, Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Infocrim");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("/html/body/table/tbody/tr[3]/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]/td[3]/input")).SendKeys(login);
                    driver.FindElement(By.XPath("/html/body/table/tbody/tr[3]/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[2]/td[3]/input")).SendKeys(senha);
                    driver.FindElement(By.XPath("/html/body/table/tbody/tr[3]/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[2]/td[4]/a/img")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }

        public bool AuthSiel(string email, string senha)
        {
            try
            {
                var url = GetUrl("Siel");
                if (url != null)
                {
                    if (driver.Url != url)
                    {
                        driver.Navigate().GoToUrl(url);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form/table/tbody/tr[1]/td[2]/input")).SendKeys(email);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form/table/tbody/tr[2]/td[2]/input")).SendKeys(senha);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form/table/tbody/tr[3]/td[2]/input")).Click();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthSiel(string email, string senha, Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Siel");
                if (url != null)
                {
                    if (driver.Url != url)
                    {
                        driver.Navigate().GoToUrl(url);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form/table/tbody/tr[1]/td[2]/input")).SendKeys(email);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form/table/tbody/tr[2]/td[2]/input")).SendKeys(senha);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form/table/tbody/tr[3]/td[2]/input")).Click();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }

        public bool AuthSivec(string usuario, string senha)
        {
            try
            {
                var url = GetUrl("Sivec");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.Id("nomeusuario")).SendKeys(usuario);
                    driver.FindElement(By.Id("senhausuario")).SendKeys(senha);
                    driver.FindElement(By.Id("Acessar")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AuthSivec(string usuario, string senha, Action<IWebDriver> action)
        {
            try
            {
                var url = GetUrl("Sivec");
                if (url != null)
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.Id("nomeusuario")).SendKeys(usuario);
                    driver.FindElement(By.Id("senhausuario")).SendKeys(senha);
                    driver.FindElement(By.Id("Acessar")).Click();
                    if (driver.Url != url)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                action(driver);
            }
        }


        public List<ArispViewModel> ScrapingArisp(string documento)
        {
            try
            {
                var logado = AuthArisp();
                if (logado == true)
                {
                    var extracaoArisp = new List<ArispViewModel>();

                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.MoveToElement(driver.FindElement(By.Id("liInstituicoes"))).Perform();
                    driver.FindElement(By.XPath("//*[@id='liInstituicoes']/div/ul/li[3]/a")).Click();
                    driver.FindElement(By.Id("Prosseguir")).Click();

                    var nomeExtracao = driver.FindElement(By.XPath("//*[@id='sessiondisplay']/b")).Text;

                    driver.FindElement(By.XPath("//*[@id='main']/div[3]/div[2]/div[1]/div/div[2]/div/label")).Click();
                    driver.FindElement(By.Id("chkHabilitar")).Click();
                    driver.FindElement(By.Id("Prosseguir")).Click();
                    driver.FindElement(By.Name("filterDocumento")).SendKeys(documento);
                    driver.FindElement(By.Id("btnPesquisar")).Click();
                    driver.FindElement(By.Id("chk339")).Click();
                    IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                    driver.FindElement(By.XPath("//*[@id='btnProsseguir']")).Click();
                    driver.FindElement(By.XPath("//*[@id='panelMatriculas']/tr[2]/td[4]/a")).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());

                    var rootPath = _conf["PathUpload"];
                    var folder = $"{rootPath}\\Arisp\\";

                    var dataAtual = DateTime.Now.ToString("ddMMyyyy HHmmss");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(folder + documento + dataAtual + ".png", ScreenshotImageFormat.Png);

                    extracaoArisp.Add(new ArispViewModel
                    {
                        Nome = nomeExtracao.ToLower(),
                        Documento = documento,
                        NomeOriginal = documento + dataAtual + ".png"
                    });

                    driver.SwitchTo().Window(driver.WindowHandles.First());
                    driver.FindElement(By.XPath("//*[@id='panelMatriculas']/tr[5]/td[4]/a")).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());

                    dataAtual = DateTime.Now.ToString("ddMMyyyy HHmmss");

                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(folder + documento + dataAtual + "-2.png", ScreenshotImageFormat.Png);

                    extracaoArisp.Add(new ArispViewModel
                    {
                        Nome = nomeExtracao.ToLower(),
                        Documento = documento,
                        NomeOriginal = documento + dataAtual + "-2.png"
                    });

                    return extracaoArisp;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }

        public ArpenspViewModel ScrapingArpensp(string numeroProcesso)
        {
            var url = GetUrl("Arpenp");
            if (url != null)
            {
                try
                {
                    driver.Navigate().GoToUrl(url);
                    driver.FindElement(By.XPath("//*[@id='main']/div[2]/div[2]/div[2]/div")).Click();
                    driver.FindElement(By.XPath("//*[@id='wrapper']/ul/li[2]/a")).Click();
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                    driver.FindElement(By.XPath("//*[@id='wrapper']/ul/li[2]/ul/li[1]/a")).Click();
                    driver.FindElement(By.XPath("//*[@id='n']")).Click();
                    driver.FindElement(By.XPath("//*[@id='principal']/div/form/table/tbody/tr[2]/td[2]/input")).SendKeys(numeroProcesso);
                    driver.FindElement(By.XPath("//*[@id='btn_pesquisar']")).Click();

                    var extracao = new ArpenspViewModel
                    {
                        CartorioRegistro = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[1]/tbody/tr[1]/td[2]/b")).Text,
                        NumeroCNS = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[1]/tbody/tr[2]/td[2]/b")).Text,
                        UF = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[1]/tbody/tr[3]/td[2]/b")).Text,
                        NomeConjuge1 = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[2]/td[2]")).Text,
                        NomeNovoConjuge1 = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[3]/td[2]")).Text,
                        NomeConjuge2 = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[4]/td[2]")).Text,
                        NomeNovoConjuge2 = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[5]/td[2]")).Text,
                        DataCasamento = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[6]/td[2]")).Text,
                        Matricula = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[8]/td[2]/b")).Text,
                        DataEntrada = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[9]/td[2]/b")).Text,
                        DataRegistro = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[10]/td[2]")).Text,
                        Acervo = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[11]/td[2]")).Text,
                        NumeroLivro = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[12]/td[2]")).Text,
                        NumeroFolha = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[13]/td[2]")).Text,
                        NumeroRegistro = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[14]/td[2]")).Text,
                        TipoLivro = driver.FindElement(By.XPath("//*[@id='principal']/div/form/table[2]/tbody/tr[15]/td[2]/b")).Text
                    };

                    return extracao;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
                finally
                {
                    driver.Dispose();
                    driver.Quit();
                }
            }

            return null;
        }

        public CadespViewModel ScrapingCadesp(string cnpj, string login, string senha)
        {
            try
            {
                var logado = AuthCadesp(login, senha);
                if (logado == true)
                {
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.MoveToElement(driver.FindElement(By.XPath("//*[@id='ctl00_menuPlaceHolder_menuControl1_LoginView1_menuSuperiorn1']/table"))).Perform();
                    driver.FindElement(By.XPath("//*[@id='ctl00_menuPlaceHolder_menuControl1_LoginView1_menuSuperiorn8']/td/table/tbody/tr/td/a")).Click();
                    var consultas = driver.FindElement(By.Id("ctl00_conteudoPaginaPlaceHolder_tcConsultaCompleta_TabPanel1_lstIdentificacao"));
                    var selectElement = new SelectElement(consultas);
                    selectElement.SelectByText("CNPJ");
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_tcConsultaCompleta_TabPanel1_txtIdentificacao']")).SendKeys(cnpj);
                    driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_tcConsultaCompleta_TabPanel1_btnConsultarEstabelecimento']")).Click();

                    var extracao = new CadespViewModel
                    {
                        Situacao = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlCabecalho']/tbody/tr/td/table/tbody/tr[2]/td[3]")).Text.Replace("Situação:", "").Replace(" ", ""),
                        RegimeEstadual = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlCabecalho']/tbody/tr/td/table/tbody/tr[4]/td[3]")).Text.Replace("Regime Estadual:", "").Replace(" ", ""),
                        DRT = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlCabecalho']/tbody/tr/td/table/tbody/tr[5]/td[2]")).Text,
                        PostoFiscal = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlCabecalho']/tbody/tr/td/table/tbody/tr[5]/td[3]")).Text.Replace("Posto Fiscal:", "").Replace(" ", ""),
                        IE = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlCabecalho']/tbody/tr/td/table/tbody/tr[2]/td[2]")).Text,
                        CNPJ = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlCabecalho']/tbody/tr/td/table/tbody/tr[3]/td[2]")).Text,
                        NomeEmpresarial = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlCabecalho']/tbody/tr/td/table/tbody/tr[4]/td[2]")).Text,
                        NomeFantasia = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[2]/td[2]")).Text,
                        DataInscricaoEstado = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[3]/td[4]")).Text,
                        DataInicioSituacao = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[7]/td[4]")).Text,
                        DataIE = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[4]/td[4]")).Text,
                        NIRE = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral_ctl01_lnkNire']")).Text,
                        SituacaoCadastral = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[7]/td[2]")).Text,
                        OcorrenciaFiscal = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[8]/td[2]")).Text,
                        TipoUnidade = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[10]/td[2]")).Text,
                        InicioIE = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[4]/td[4]")).Text,
                        InicioSituacao = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral']/tbody/tr[2]/td/table/tbody/tr[7]/td[4]")).Text,
                        FormaAtuacao = driver.FindElement(By.XPath("//*[@id='ctl00_conteudoPaginaPlaceHolder_dlEstabelecimentoGeral_ctl01_dlEstabelecimentoFormasAtuacao']/tbody/tr/td/table/tbody/tr/td")).Text
                    };

                    return extracao;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }

        public CagedViewModel ScrapingCaged(string cpf, string senha, string cnpj, string chavePesquisa)
        {
            try
            {
                var logado = AuthCaged(cpf, senha);
                if (logado == true)
                {
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.MoveToElement(driver.FindElement(By.XPath("//*[@id='nav']/li[1]/a"))).Perform();
                    driver.FindElement(By.Id("j_idt12:idMenuLinkAutorizado")).Click();
                    driver.FindElement(By.Id("formPesquisarAutorizado:txtChavePesquisaAutorizado014")).SendKeys(chavePesquisa);
                    driver.FindElement(By.Id("formPesquisarAutorizado:bt027_8")).Click();

                    //Extracao Reponsavel pela Empresa
                    var extracaoResponsavel = new DadosCaged
                    {
                        Documento = driver.FindElement(By.XPath("//*[@id='txCnpj020_2']")).Text,
                        RazaoSocialNome = driver.FindElement(By.XPath("//*[@id='txtrazaosocial020_4']")).Text,
                        Logradouro = driver.FindElement(By.XPath("//*[@id='txt3_logradouro020']")).Text,
                        BairroDistrito = driver.FindElement(By.XPath("//*[@id='txt4_bairro020']")).Text,
                        Municipio = driver.FindElement(By.XPath("//*[@id='conteudo']/fieldset[2]/div[3]/div/div[2]")).Text,
                        UF = driver.FindElement(By.XPath("//*[@id='txt7_uf020']")).Text,
                        Cep = driver.FindElement(By.XPath("//*[@id='txt8_cep020']")).Text,
                        Nome = driver.FindElement(By.XPath("//*[@id='txt_nome_contato']")).Text,
                        Cpf = driver.FindElement(By.XPath("//*[@id='txt_contato_cpf']")).Text,
                        Telefone = driver.FindElement(By.XPath("//*[@id='conteudo']/fieldset[3]/div[3]/div[1]/div[2]")).Text,
                        Ramal = driver.FindElement(By.XPath("//*[@id='txt10_ramal020']")).Text,
                        Email = driver.FindElement(By.XPath("//*[@id='txt11_email']")).Text,
                    };

                    var action2 = new OpenQA.Selenium.Interactions.Actions(driver);
                    action2.MoveToElement(driver.FindElement(By.XPath("//*[@id='nav']/li[1]/a"))).Perform();
                    driver.FindElement(By.Id("j_idt12:idMenuLinkEmpresaCaged")).Click();
                    driver.FindElement(By.Id("formPesquisarEmpresaCAGED:txtcnpjRaiz")).SendKeys(cnpj);
                    driver.FindElement(By.Id("formPesquisarEmpresaCAGED:btConsultar")).Click();

                    //Extracao da Empresa
                    var extracaoEmpresa = new Empresa
                    {
                        CnpjRaiz = driver.FindElement(By.Id("formResumoEmpresaCaged:txtCnpjRaiz")).Text,
                        RazaoSocial = driver.FindElement(By.Id("formResumoEmpresaCaged:txtRazaoSocial")).Text,
                        AtividadeEconomica = driver.FindElement(By.XPath("//*[@id='formResumoEmpresaCaged']/fieldset[1]/div[3]/div/div[2]")).Text,
                        NumeroFiliais = driver.FindElement(By.Id("formResumoEmpresaCaged:txtNumFiliais")).Text,
                        Admissoes = driver.FindElement(By.Id("formResumoEmpresaCaged:txtTotalNumAdmissoes")).Text,
                        VariacaoAbsoluta = driver.FindElement(By.Id("formResumoEmpresaCaged:txtTotalVariacaoAbosulta")).Text,
                        TotalVinculos = driver.FindElement(By.Id("formResumoEmpresaCaged:txtTotalVinculos")).Text,
                        Desligamentos = driver.FindElement(By.Id("formResumoEmpresaCaged:txtTotalNumDesligamentos")).Text,
                        PrimeiroDia = driver.FindElement(By.Id("formResumoEmpresaCaged:txtTotalNumPrimDia")).Text,
                        UltimoDia = driver.FindElement(By.Id("formResumoEmpresaCaged:txtTotalNumUltDia")).Text,
                    };

                    var action3 = new OpenQA.Selenium.Interactions.Actions(driver);
                    action3.MoveToElement(driver.FindElement(By.XPath("//*[@id='nav']/li[1]/a"))).Perform();
                    driver.FindElement(By.Id("j_idt12:idMenuLinkTrabalhador")).Click();
                    driver.FindElement(By.Id("formPesquisarTrabalhador:txtChavePesquisa")).SendKeys(chavePesquisa);
                    driver.FindElement(By.Id("formPesquisarTrabalhador:submitPesqTrab")).Click();

                    //Extracao do Trabalhador
                    var extracaoTrabalhador = new Trabalhador
                    {
                        Nome = driver.FindElement(By.XPath("//*[@id='txt2_Nome027']")).Text,
                        PisBase = driver.FindElement(By.XPath("//*[@id='txt1_Pis028']")).Text,
                        Cpf = driver.FindElement(By.XPath("//*[@id='txt3_Cpf027']")).Text,
                        Ctps = driver.FindElement(By.XPath("//*[@id='txt5_Ctps027']")).Text,
                        DataNascimento = driver.FindElement(By.XPath("//*[@id='txt4_datanasc027']")).Text,
                        Deficiencia = driver.FindElement(By.XPath("//*[@id='txt13_Def027']")).Text,
                        GrauInstrucao = driver.FindElement(By.XPath("//*[@id='txt12_Instr027']")).Text,
                        Nacionalidade = driver.FindElement(By.XPath("//*[@id='txt8_Nac027']")).Text,
                        Raca = driver.FindElement(By.XPath("//*[@id='txt10_Raca027']")).Text,
                        Sexo = driver.FindElement(By.XPath("//*[@id='txt6_Sexo027']")).Text,
                        Situacao = driver.FindElement(By.XPath("//*[@id='txt4_SitPis027']")).Text,
                        TempoTrabalho = driver.FindElement(By.XPath("//*[@id='txt26_Caged027']")).Text,
                    };
                    return new CagedViewModel
                    {
                        Empresa = extracaoEmpresa,
                        Trabalhador = extracaoTrabalhador,
                        DadosCaged = extracaoResponsavel
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }

        public CensecViewModel ScrapingCensec(string login, string senha, string documento)
        {
            try
            {
                var logado = AuthCensec(login, senha);
                if (logado == true)
                {
                    var action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.MoveToElement(driver.FindElement(By.XPath("//*[@id='menucentrais']"))).Perform();
                    action.MoveToElement(driver.FindElement(By.XPath("//*[@id='ctl00_CESDILi']/a"))).Perform();
                    driver.FindElement(By.XPath("//*[@id='ctl00_CESDIConsultaAtoHyperLink']")).Click();
                    driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_DocumentoTextBox']")).SendKeys(documento);
                    driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_BuscarButton']")).Click();
                    driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_ResultadoBuscaGeralPanel']/div[2]/div[1]/div/table/tbody/tr[2]/td[1]/input")).Click();
                    driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_VisualizarButton']")).Click();

                    var extracao = new CensecViewModel
                    {
                        Carga = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_CodigoTextBox']")).GetAttribute("value"),
                        Ato = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_TipoAtoDropDownList']/option")).GetAttribute("value"),
                        Livro = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_LivroTextBox']")).GetAttribute("value"),
                        Folha = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_FolhaTextBox']")).GetAttribute("value"),
                        DiaAto = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_DiaAtoTextBox']")).GetAttribute("value"),
                        MesAto = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_MesAtoTextBox']")).GetAttribute("value"),
                        AnoAto = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_AnoAtoTextBox']")).GetAttribute("value"),
                        MesCarga = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_MesReferenciaDropDownList']")).Text.Replace(" ", ""),
                        AnoCarga = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_AnoReferenciaDropDownList']")).Text.Replace(" ", ""),
                    };
                    return extracao;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }

        public SielViewModel ScrapingSiel(string email, string senha, string nome, string numeroProcesso)
        {
            try
            {
                var logado = AuthSiel(email, senha);
                if (logado == true)
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form[2]/fieldset[1]/table/tbody/tr[1]/td[2]/input")).SendKeys(nome);
                    driver.FindElement(By.Id("num_processo")).SendKeys(numeroProcesso);
                    driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/form[2]/table/tbody/tr/td[2]/input")).Click();

                    var extracao = new SielViewModel
                    {
                        Nome = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[2]/td[2]")).Text,
                        Titulo = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[3]/td[2]")).Text,
                        DataNascimento = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[4]/td[2]")).Text,
                        Zona = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[5]/td[2]")).Text,
                        Endereco = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[6]/td[2]")).Text,
                        Municipio = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[7]/td[2]")).Text,
                        UF = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[8]/td[2]")).Text,
                        DataDomicilio = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[9]/td[2]")).Text,
                        NomePai = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[10]/td[2]")).Text,
                        NomeMae = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[11]/td[2]")).Text,
                        Naturalidade = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[12]/td[2]")).Text,
                        CodigoValidacao = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[4]/table/tbody/tr[13]/td[2]")).Text,
                    };
                    return extracao;

                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }

        public SivecViewModel ScrapingSivec(string opcao, string rg, string nome, string matriculaSap, string usuario, string senha)
        {
            try
            {
                var logado = AuthSivec(usuario, senha);
                if (logado == true)
                {
                    if (opcao.ToLower() == "rg")
                    {
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/a")).Click();
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/ul/li[2]/a")).Click();
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/ul/li[2]/ul/li[1]/a")).Click();
                        driver.FindElement(By.Id("idValorPesq")).SendKeys(rg);
                        driver.FindElement(By.Id("procurar")).Click();

                        driver.FindElement(By.XPath("//*[@id='tabelaPesquisa']/tbody/tr[1]/td[1]/a")).Click();

                    }
                    else if (opcao.ToLower() == "nome")
                    {
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/a")).Click();
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/ul/li[2]/a")).Click();
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/ul/li[2]/ul/li[2]/a")).Click();
                        driver.FindElement(By.Id("idNomePesq")).SendKeys(nome);
                        driver.FindElement(By.Id("procura")).Click();
                        driver.FindElement(By.XPath("//*[@id='tabelaPesquisa']/tbody/tr[1]/td[1]/a")).Click();

                    }
                    else if (opcao.ToLower() == "matricula")
                    {

                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/a")).Click();
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/ul/li[2]/a")).Click();
                        driver.FindElement(By.XPath("/html/body/nav/div[2]/ul/li[4]/ul/li[2]/ul/li[3]/a")).Click();
                        driver.FindElement(By.Id("idValorPesq")).SendKeys(matriculaSap);
                        driver.FindElement(By.Id("procurar")).Click();
                        driver.FindElement(By.XPath("//*[@id='tabelaPesquisa']/tbody/tr[1]/td[1]/a")).Click();
                    }

                    var extracao = new SivecViewModel
                    {
                        Nome = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[2]/table/tbody/tr[1]/td[2]/span")).Text,
                        DataNascimento = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[2]/table/tbody/tr[2]/td[2]/span")).Text,
                        Sexo = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[2]/table/tbody/tr[1]/td[5]/span")).Text,
                        Rg = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[2]/table/tbody/tr[2]/td[5]/span")).Text,
                        TipoRg = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[2]/table/tbody/tr[3]/td[5]/span")).Text,
                        DataEmissao = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[1]/td[2]/span")).Text,
                        EstadoCivil = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[2]/td[2]/span")).Text,
                        Naturalizado = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[3]/td[2]/span")).Text,
                        GrauInstrucao = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[4]/td[2]/span")).Text,
                        NomePai = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[5]/td[2]/span")).Text,
                        NomeMae = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[6]/td[2]/span")).Text,
                        CorPele = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[7]/td[2]/span")).Text,
                        Alcunha = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[1]/td[5]/span")).Text,
                        Naturalidade = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[2]/td[5]/span")).Text,
                        Posto = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[3]/td[5]/span")).Text,
                        Formula = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[4]/td[5]/span")).Text,
                        CorOlho = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[5]/td[5]/span")).Text,
                        Cabelo = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[6]/td[5]/span")).Text,
                        Profissao = driver.FindElement(By.XPath("/html/body/form[1]/div/div[5]/div[4]/table/tbody/tr[7]/td[5]/span")).Text,
                        EnderecoResidencial = driver.FindElement(By.XPath("/html/body/form[1]/div/div[7]/div[2]/span")).Text,
                        EnderecoTrabalho = driver.FindElement(By.XPath("/html/body/form[1]/div/div[8]/div[2]/span")).Text
                    };

                    return extracao;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }

        public DetranViewModel ScrapingDetran(string login, string senha, int opcao, string cpf, string placa, string nome)
        {
            try
            {
                var logado = AuthDetran(login, senha);
                if (logado == true)
                {
                    if (opcao == 1 && cpf != null && nome != null)
                    {
                        driver.Manage().Window.Maximize();
                        var action = new OpenQA.Selenium.Interactions.Actions(driver);
                        action.MoveToElement(driver.FindElement(By.Id("navigation_a_M_16"))).Perform();
                        driver.FindElement(By.XPath("//*[@id='navigation_ul_M_16']/li[2]/a")).Click();
                        driver.FindElement(By.Id("form:cpf")).Click();
                        driver.FindElement(By.Id("form:cpf")).SendKeys(cpf);
                        driver.FindElement(By.XPath("//*[@id='form:pnQuery_content']/table[3]/tbody/tr/td/a/span")).Click();
                        driver.SwitchTo().Window(driver.WindowHandles.Last());

                        var rootPath = _conf["PathUpload"];
                        var folder = $"{rootPath}\\Detran\\";

                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }

                        var dataAtual = DateTime.Now.ToString("ddMMyyyy HHmmss");

                        ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(folder + cpf + dataAtual + ".png", ScreenshotImageFormat.Png);

                        var extracaoDetran = new DetranViewModel
                        {
                            NomeOriginalCondutorIMG = cpf + dataAtual + ".png",
                        };

                        driver.SwitchTo().Window(driver.WindowHandles.First());
                        var action2 = new OpenQA.Selenium.Interactions.Actions(driver);
                        action2.MoveToElement(driver.FindElement(By.Id("navigation_a_M_16"))).Perform();
                        driver.FindElement(By.XPath("//*[@id='navigation_ul_M_16']/li[1]/a")).Click();
                        driver.FindElement(By.Id("form:cpf")).Click();
                        driver.FindElement(By.Id("form:cpf")).SendKeys(cpf);
                        driver.FindElement(By.Id("form:nome")).Click();
                        driver.FindElement(By.Id("form:nome")).SendKeys(nome);
                        driver.FindElement(By.XPath("//*[@id='form:j_id2049423534_c43228e_content']/table[3]/tbody/tr/td/a/span")).Click();
                        driver.SwitchTo().Window(driver.WindowHandles.Last());

                        StringBuilder linhaDeVida = new StringBuilder();

                        using (PdfReader reader = new PdfReader(driver.Url))
                        {

                            for (int page = 1; page <= reader.NumberOfPages; page++)
                            {
                                SimpleTextExtractionStrategy strategy =
                                    new SimpleTextExtractionStrategy();
                                string pageText =
                                    PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                                linhaDeVida.Append(pageText);
                            }
                        }

                        extracaoDetran.NomeOriginalCondutorPDF = linhaDeVida.ToString();

                        return extracaoDetran;

                    }
                    else if (opcao == 2 && cpf != null && placa != null)
                    {
                        var action = new OpenQA.Selenium.Interactions.Actions(driver);
                        action.MoveToElement(driver.FindElement(By.Id("navigation_a_M_18"))).Perform();
                        driver.FindElement(By.XPath("//*[@id='navigation_a_F_18']")).Click();
                        //PLACA
                        driver.FindElement(By.Id("form:j_id2124610415_1b3be1bd")).SendKeys(placa);
                        //CPF
                        driver.FindElement(By.Id("form:j_id2124610415_1b3be1e3")).SendKeys(cpf);
                        driver.FindElement(By.XPath("//*[@id='form:j_id2124610415_1b3be155_content']/table[3]/tbody/tr/td/a/span")).Click();
                        driver.SwitchTo().Window(driver.WindowHandles.Last());


                        StringBuilder veiculo = new StringBuilder();

                        using (PdfReader reader2 = new PdfReader(driver.Url))
                        {

                            for (int page2 = 1; page2 <= reader2.NumberOfPages; page2++)
                            {
                                SimpleTextExtractionStrategy strategy2 =
                                    new SimpleTextExtractionStrategy();
                                string pageText2 =
                                    PdfTextExtractor.GetTextFromPage(reader2, page2, strategy2);
                                veiculo.Append(pageText2);
                            }
                        }

                        return new DetranViewModel { NomeOriginalVeiculo = veiculo.ToString() };
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }

        public InfocrimViewModel ScrapingInfrocrim(string usuario, string senha)
        {
            try
            {
                var logado = AuthInfocrim(usuario, senha);
                if (logado == true)
                {
                    driver.FindElement(By.XPath("/html/body/a/table[3]/tbody/tr/td[2]/table[1]/tbody/tr[3]/td/table/tbody/tr[2]/td/table/tbody/tr/td/div/a/img")).Click();
                    driver.FindElement(By.XPath("/html/body/table/tbody/tr[2]/td/table[3]/tbody/tr[2]/td[2]/a")).Click();

                    var rootPath = _conf["PathUpload"];
                    var folder = $"{rootPath}\\Infocrim\\";

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    var dataAtual = DateTime.Now.ToString("ddMMyyyy HHmmss");

                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(folder + "bo-" + dataAtual + ".png", ScreenshotImageFormat.Png);

                    var extracaoInfocrim = new InfocrimViewModel
                    {
                        NomeOriginal = "bo-" + dataAtual + ".png"
                    };

                    return extracaoInfocrim;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }

        }

        public JucespViewModel ScrapingJucesp(string nomeEmpresa)
        {
            try
            {
                var url = GetUrl("Jucesp");
                driver.Navigate().GoToUrl(url);
                driver.FindElement(By.Id("ctl00_cphContent_frmBuscaSimples_txtPalavraChave")).SendKeys(nomeEmpresa);
                driver.FindElement(By.XPath("//*[@id='ctl00_cphContent_frmBuscaSimples_pnlBuscaSimples']/table/tbody/tr/td[2]/input")).Click();
                driver.FindElement(By.XPath("//*[@id='formBuscaAvancada']/table/tbody/tr[2]/td/input")).Click();
                driver.FindElement(By.Id("ctl00_cphContent_gdvResultadoBusca_gdvContent_ctl02_lbtSelecionar")).Click();

                var tipoEmpresa = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblDetalhes")).Text;
                var dataConst = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblConstituicao")).Text;
                var inicioAtivividade = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblAtividade")).Text;
                var cnpj = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblCnpj")).Text;
                var objeto = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblObjeto")).Text;
                var capital = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblCapital")).Text;
                var logradouro = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblLogradouro")).Text;
                var bairro = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblBairro")).Text;
                var municipio = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblMunicipio")).Text;
                var numero = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblNumero")).Text;
                var complemento = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblComplemento")).Text;
                var cep = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblCep")).Text;
                var uf = driver.FindElement(By.Id("ctl00_cphContent_frmPreVisualiza_lblUf")).Text;



                driver.FindElement(By.XPath("//*[@id='ctl00_cphContent_frmPreVisualiza_rblTipoDocumento']/tbody/tr[2]/td/label")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_cphContent_frmPreVisualiza_UpdatePanel2']/input")).Click();

                //Extração do PDF

                StringBuilder ficha = new StringBuilder();

                using (PdfReader reader = new PdfReader(driver.Url))
                {

                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        SimpleTextExtractionStrategy strategy =
                            new SimpleTextExtractionStrategy();
                        string pageText =
                            PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                        ficha.Append(pageText);
                    }
                }

                var extracaoDados = new ExtracaoJucesp
                {
                    Ficha = ficha.ToString(),
                    Bairro = bairro,
                    Capital = capital,
                    Cep = cep,
                    Cnpj = cnpj,
                    Complemento = complemento,
                    InicioAtividade = inicioAtivividade,
                    Logradouro = logradouro,
                    Municipio = municipio,
                    NomeEmpresa = nomeEmpresa,
                    Objeto = objeto,
                    Numero = numero,
                    DataConst = dataConst,
                    DataUploadFicha = DateTime.Now

                };
                return extracaoDados;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                driver.Dispose();
                driver.Quit();
            }
        }
    }

}

