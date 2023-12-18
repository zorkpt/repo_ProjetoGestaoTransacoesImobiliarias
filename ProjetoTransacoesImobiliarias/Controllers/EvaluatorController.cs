using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class EvaluatorController : UserController
{
    private readonly Evaluator _evaluator;
    private ProposalController proposalController;
    private TransactionController transactionController;
    private EvaluatorView evaluatorView { get; set; }
    private VisitsController visitsController;
    private PropertyController propertyController;

    private AssessmentController _assessmentController;
    public EvaluatorController(Evaluator evaluator, IUserService userService, IClientService clientService, IPropertyService propertyService)
        : base(userService, clientService, propertyService, new ProposalController(), new TransactionController(), new PropertyController(), new VisitsController())
    {
        _evaluator = evaluator;
        evaluatorView = new EvaluatorView();
        _assessmentController = new AssessmentController();
    }

    /// <summary>
    /// Executes the menu functionality for the evaluator user.
    /// </summary>
    public override void MenuStart()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = EvaluatorView.ShowEvaluatorMenu(_evaluator);
            switch (option)
            {
                case "1":
                    AddAssessmentProperty();
                    break;
                case "2":
                    ListAssessmentProperty();
                    break;
                case "0":
                    exitMenu = true;
                    break;
                default:
                    MessageHandler.WrongOption();
                    break;
            }
        }
    }



    // Methods

    /// <summary>
    /// List all assessments of a property
    /// </summary>
    private void ListAssessmentProperty()
    {
        Console.Clear();
        //Tabela de avaliações
        Console.WriteLine("========== Avaliações ==========");
        foreach (var assessment in Assessment.AssessmentList)
        {
            // Exibir informações da avaliação
            Console.WriteLine($"Avaliação ID: {assessment.Id} \nAvaliador: {assessment.evaluator.Name} \nPropriedade: {assessment.property.Id} \nData: {assessment.assessmentDate} \nValor: {assessment.assessmentValue}\n");
        }
        MessageHandler.PressAnyKey();
    }

    /// <summary>
    /// Add new assessment to property
    /// </summary>
    private void AddAssessmentProperty()
    {
        var propertyId = EvaluatorView.EvaluateAddAssessmentPropertyView(_evaluator);
        if (propertyId.HasValue)
        {
            var property = _propertyService.GetPropertyById(propertyId.Value);
            if (property != null)
            {
                var assessmentDate = DateTime.Now;

                // Pedir ao avaliador para inserir o valor da avaliação
                Console.WriteLine("Insira o valor da avaliação:");
                decimal assessmentValue;
                while (!decimal.TryParse(Console.ReadLine(), out assessmentValue))
                {
                    Console.WriteLine("Valor inválido, por favor insira um número decimal válido (por exemplo, 1000000.00):");
                }

                AssessmentController.AddAssessmentToProperty(_evaluator, property, assessmentDate, assessmentValue);
                MessageHandler.PressAnyKey("Avaliação adicionada com sucesso");
            }
            else
            {
                Console.WriteLine("Propriedade não encontrada.");
                // Outras ações, como retornar ao menu
            }
        }
        else
        {
            Console.WriteLine("ID da Propriedade inválido. Por favor, tente novamente.");
            // Retornar ao menu ou tomar outra ação apropriada
        }
    }



}