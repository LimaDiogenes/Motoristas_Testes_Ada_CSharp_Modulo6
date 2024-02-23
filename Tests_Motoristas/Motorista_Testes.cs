using FluentAssertions;
using System.ComponentModel;

/* Duvidas:
 * Como passar listas/colecoes como inline data?
 * Como criar testes para verificar que excecao foi lancada em casos que, mesmo tendo excecao, o metodo retorna sucesso/falha no final
 * */

namespace Motoristas_Testes.Tests
{

    public class Tests_Motorista
    {
        [Fact]
        [Trait("Sucesso", "Motoristas encontrados")]
        [DisplayName("MotoristasEncontrados")]
        public void Motoristas_EncontrarMotoristas_2MotoristasValidosEncontrados()
        {
            // Arrange
            var list = new List<Pessoa>
            {
                new Pessoa { Nome = "Sam", Idade = 30, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Dean", Idade = 34, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Adam", Idade = 25, PossuiHabilitacaoB = false },
            };
            var drivers = new Motoristas();

            // Act
            var response = drivers.EncontrarMotoristas(list);

            // Assert
            response.Should().StartWith("Uhuu! Os motorista são");
        }

        [Fact]
        [Trait("Falha", "Motoristas validos insuficientes")]
        [DisplayName("MotoristasInsuficientesExcecao")]
        public void Motoristas_EncontrarMotoristas_MotoristasValidosInsuficientes_ResultaEmExcecao()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Bobby", Idade = 60, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Castiel", Idade = 1000, PossuiHabilitacaoB = false },
                new Pessoa { Nome = "Crowley", Idade = 300, PossuiHabilitacaoB = false },
            };
            var drivers = new Motoristas();

            // Act 
            var act = () => drivers.EncontrarMotoristas(pessoas);

            // Assert

            act.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");
        }

        #region v1Test
        //[Fact]
        //[Trait("Falha", "Motorista menor de idade com habilitacao")]
        //[DisplayName("MotoristasMenorDeIdadeExcecao")]
        //public void Motoristas_EncontrarMotoristas_MotoristaMenorDeIdadeComHabilitacao_ResultaEmExcecao()
        //{
        //    // Arrange
        //    List<Pessoa> pessoas = new List<Pessoa>
        //    {
        //        new Pessoa { Nome = "Claire", Idade = 17, PossuiHabilitacaoB = true },
        //        new Pessoa { Nome = "Gabriel", Idade = int.MaxValue - 1, PossuiHabilitacaoB = true },
        //        new Pessoa { Nome = "Mary", Idade = 55, PossuiHabilitacaoB = true },
        //        new Pessoa { Nome = "John", Idade = 60, PossuiHabilitacaoB = true },
        //        new Pessoa { Nome = "Kevin", Idade = 20, PossuiHabilitacaoB = false },
        //        new Pessoa { Nome = "Meg", Idade = 500, PossuiHabilitacaoB = true },
        //    };
        //    var drivers = new Motoristas();

        //    // Act
        //    var act = () => drivers.EncontrarMotoristas(pessoas);

        //    // Assert
        //    act.Should().Throw<Exception>().And.Message.EndsWith("Esta pessoa deve ser removida da lista");

        //}
        #endregion
        #region v2
        [Fact]
        [Trait("Sucesso", "Motorista menor de idade")]
        [DisplayName("MenorDeIdadeComMaisMotoristasDisponiveisRetornaSucesso")]
        public void Motoristas_EncontrarMotoristas_MotoristaMenorDeIdadeComHabilitacaoIgnorado_MotoristasOk_ResultaEmSucesso()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Claire", Idade = 17, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Gabriel", Idade = int.MaxValue - 1, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Mary", Idade = 55, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "John", Idade = 60, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Kevin", Idade = 20, PossuiHabilitacaoB = false },
                new Pessoa { Nome = "Meg", Idade = 500, PossuiHabilitacaoB = true },
            };
            var drivers = new Motoristas();

            // Act
            string response = drivers.EncontrarMotoristas(pessoas);

            // Assert
            response.Should().StartWith("Uhuu! Os motorista são");

        }
        [Fact]
        [Trait("Sucesso", "Motoristas menores de idade")]
        [DisplayName("2+MenoresDeIdadeComMaisMotoristasDisponiveisRetornaSucesso")]
        public void Motoristas_EncontrarMotoristas_MotoristasMenoresDeIdadeComOuSemHabilitacaoIgnorados_MotoristasOk_ResultaEmSucesso()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Claire", Idade = 17, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Gabriel", Idade = int.MaxValue - 1, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Mary", Idade = 55, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "John", Idade = 60, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Jesse", Idade = 12, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Kevin", Idade = 20, PossuiHabilitacaoB = false },
                new Pessoa { Nome = "Ben", Idade = 15, PossuiHabilitacaoB = false },
                new Pessoa { Nome = "Meg", Idade = 500, PossuiHabilitacaoB = true },
            };
            var drivers = new Motoristas();

            // Act
            string response = drivers.EncontrarMotoristas(pessoas);

            // Assert
            response.Should().StartWith("Uhuu! Os motorista são");

        }

        [Fact]
        [Trait("Falha", "Motorista menor de idade")]
        [DisplayName("MenorDeIdadeResultaEmFaltaMotoristas")]
        public void Motoristas_EncontrarMotoristas_MotoristaMenorDeIdadeComHabilitacaoIgnorado_FaltaMotoristas_ResultaExcecao()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Claire", Idade = 17, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Jo", Idade = 30, PossuiHabilitacaoB = false },
                new Pessoa { Nome = "Ruby", Idade = 500, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Chuck", Idade = 9999, PossuiHabilitacaoB = false },
            };
            var drivers = new Motoristas();

            // Act
            Action response = () => drivers.EncontrarMotoristas(pessoas);

            // Assert
            response.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");

        }

        [Fact]
        [Trait("Falha", "Lista vazia")]
        [DisplayName("ListaVaziaResultaExcecao")]
        public void Motoristas_EncontrarMotoristas_ListaVazia_ResultaExcecao()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa> { };
 
            var drivers = new Motoristas();

            // Act
            Action response = () => drivers.EncontrarMotoristas(pessoas);

            // Assert
            response.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");
        }
        #endregion
    }
}
