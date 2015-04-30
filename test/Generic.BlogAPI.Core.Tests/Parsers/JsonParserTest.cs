using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Generic.BlogAPI.Core.Entities.FeedResponse;
using Generic.BlogAPI.Core.Parsers;
using NUnit.Framework;

namespace Generic.BlogAPI.Core.Tests.Parsers
{
    [TestFixture]
    public class JsonParserTest
    {
        private IJsonParser _jsonParser;

        [SetUp]
        public void Init()
        {
            _jsonParser = new JsonParser();
        }

        [Test]
        public void Should_DeserializeAJsonContent()
        {
            var validJson = GivenAValidPostStructureJsonAsString();

            var obtained = _jsonParser.Parse<Post>(validJson);

            obtained.Should().BeOfType(typeof(Post));
        }

        [Test]
        public void Should_SerializeAJsonContent()
        {
            var validObject = GivenAValidPostStructureJsonAsObject();

            var obtained = _jsonParser.Parse(validObject);

            string.IsNullOrWhiteSpace(obtained).Should().BeFalse();
        }

        private string GivenAValidPostStructureJsonAsString()
        {
            return @"{""status"":""ok"",""count"":1,""pages"":56,""category"":{""id"":41,""slug"":""imprensa"",""title"":""Imprensa"",""description"":"""",""parent"":0,""post_count"":56},""posts"":[{""id"":12931,""type"":""post"",""slug"":""g1-preco-seguro-auto-vendidos"",""url"":""http://blogminuto.azurewebsites.net/carro/g1-preco-seguro-auto-vendidos/"",""status"":""publish"",""title"":""G1 compara o preço do seguro auto dos mais vendidos"",""title_plain"":""G1 compara o preço do seguro auto dos mais vendidos"",""content"":""<p><a href=\""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg\"" onclick=\""_gaq.push(['_trackEvent', 'outbound-article-int', 'http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg', '']);\"" ><img class=\""alignright  wp-image-12941\"" src=\""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg\"" alt=\""Fiat Strada - seguro auto\"" width=\""223\"" height=\""157\"" /></a>A pedido do <strong>G1</strong> (principal portal de notícias da Globo.com), a Minuto Seguros contribuiu com um levantamento do <strong><a href=\""http://www.minutoseguros.com.br/seguros/seguro-carro\"" onclick=\""_gaq.push(['_trackEvent', 'outbound-article', 'http://www.minutoseguros.com.br/seguros/seguro-carro', 'seguro auto']);\""  target=\""_blank\"">seguro auto</a></strong> dos modelos mais vendidos do país recentemente.</p>\n<p>A ideia é justamente mostrar o quanto os preços podem variar em determinadas cidades do Brasil. Além da localidade, muitos outros fatores influenciam do <a href=\""http://www.minutoseguros.com.br/blog/carro/que-influencia-valor-seguro-auto/\"" onclick=\""_gaq.push(['_trackEvent', 'outbound-article', 'http://www.minutoseguros.com.br/blog/carro/que-influencia-valor-seguro-auto/', 'valor do seguro']);\""  target=\""_blank\"">valor do seguro</a> como o carro em si, o perfil do condutor, a característica de condução, local de estadia, etc.</p>\n<p>A lista pedida pelo portal contemplou os seguintes automóveis: Ford Ka, Fiat Palio, Chevrolet Onix, Volkswagen Gol, Fiat Strada, Hyundai HB20, Fiat Novo Uno, Volkswagen Saveiro, Renault Sandero e Chevrolet Prisma.</p>\n<p>Por serem de outra categoria, as picapes se destacaram como as mais caras do levantamento do G1, que ainda contou com dados de outra corretora. A Strada (foto) foi a mais cara em três das cinco capitais avaliadas, enquanto a Saveiro dominou as restantes.</p>\n<p>Já o mais barato foi o Ford Ka, que por ser um novo modelo no mercado, acaba sendo “beneficiado” com cotações mais em conta, uma vez que existe uma espécie de falta de experiência nas seguradoras em precificá-los. Elas normalmente entram com um custo de um modelo similar e calibram (aumentando ou diminuindo) ao longo do tempo.</p>\n<p>O novo carro da Ford só foi superado como mais barato em uma cidade, São Paulo, que teve o Chevrolet Onix como o mais em conta.</p>\n<p>Acesse o link da <a href=\""http://g1.globo.com/carros/noticia/2015/03/seguro-de-carros-mais-vendidos-varia-ate-350-em-5-capitais.html\"" onclick=\""_gaq.push(['_trackEvent', 'outbound-article', 'http://g1.globo.com/carros/noticia/2015/03/seguro-de-carros-mais-vendidos-varia-ate-350-em-5-capitais.html', 'matéria no G1']);\""  target=\""_blank\"">matéria no G1</a> e veja os resultados detalhados.<br />\n<em>(foto: divulgação)</em></p>\n<div class='yarpp-related'>\n<h3>Posts relacionados:</h3><ol>\n<li><a href=\""http://blogminuto.azurewebsites.net/carro/minuto-seguros-estudo-jovens-seguro-auto/\"" rel=\""bookmark\"" title=\""Minuto Seguros faz estudo sobre jovens e seguro auto\"">Minuto Seguros faz estudo sobre jovens e seguro auto </a></li>\n<li><a href=\""http://blogminuto.azurewebsites.net/carro/minuto-seguros-levantamento-seguro-suvs/\"" rel=\""bookmark\"" title=\""Minuto Seguros faz levantamento de seguro para SUVs\"">Minuto Seguros faz levantamento de seguro para SUVs </a></li>\n<li><a href=\""http://blogminuto.azurewebsites.net/carro/nao-chove-nao-lavo-carro/\"" rel=\""bookmark\"" title=\""Enquanto não chove, não lavo meu carro!\"">Enquanto não chove, não lavo meu carro! </a></li>\n<li><a href=\""http://blogminuto.azurewebsites.net/carro/seguro-carros-mais-vendidos-janeiro/\"" rel=\""bookmark\"" title=\""O seguro dos carros mais vendidos em Janeiro\"">O seguro dos carros mais vendidos em Janeiro </a></li>\n</ol>\n</div>\n"",""excerpt"":""<p>A pedido do G1 (principal portal de notícias da Globo.com), a Minuto Seguros contribuiu com um levantamento do seguro auto dos modelos mais vendidos do país&hellip;</p>\n"",""date"":""2015-03-17 22:12:38"",""modified"":""2015-03-17 22:12:38"",""categories"":[{""id"":11,""slug"":""carro"",""title"":""Carro"",""description"":"""",""parent"":0,""post_count"":97},{""id"":41,""slug"":""imprensa"",""title"":""Imprensa"",""description"":"""",""parent"":0,""post_count"":56}],""tags"":[],""author"":{""id"":31,""slug"":""ique-muniz"",""name"":""Ique Muniz"",""first_name"":""Ique"",""last_name"":""Muniz"",""nickname"":""ique.muniz"",""url"":"""",""description"":""""},""comments"":[],""attachments"":[{""id"":12941,""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""slug"":""strada-fiat"",""title"":""strada-fiat"",""description"":"""",""caption"":"""",""parent"":12931,""mime_type"":""image/jpeg"",""images"":{""full"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""medium"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""large"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""watson_featured"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""watson_featured_index"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat-205x145.jpg"",""width"":205,""height"":145},""watson_recent_posts_widget"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat-88x64.jpg"",""width"":88,""height"":64},""watson_featured_thumbnail"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat-115x75.jpg"",""width"":115,""height"":75}}}],""comment_count"":0,""comment_status"":""open"",""thumbnail"":null,""custom_fields"":{""watson_featured_thumbnail"":[""""]},""thumbnail_size"":""thumbnail"",""thumbnail_images"":{""full"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""medium"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""large"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""watson_featured"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat.jpg"",""width"":304,""height"":206},""watson_featured_index"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat-205x145.jpg"",""width"":205,""height"":145},""watson_recent_posts_widget"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat-88x64.jpg"",""width"":88,""height"":64},""watson_featured_thumbnail"":{""url"":""http://blogminuto.azurewebsites.net/wp-content/uploads/2015/03/strada-fiat-115x75.jpg"",""width"":115,""height"":75}}}]}";
        }

        private Post GivenAValidPostStructureJsonAsObject()
        {
            return new Post
            {
                date = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                title = "title",
                categories = new List<Category> {new Category {title = "category"}},
                content = "content"
            };
        }
    }
}