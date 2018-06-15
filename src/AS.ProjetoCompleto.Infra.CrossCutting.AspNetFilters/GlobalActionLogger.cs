using System.Web.Mvc;

namespace AS.ProjetoCompleto.Infra.CrossCutting.AspNetFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //log de auditoria

            if(filterContext.Exception != null)
            {
                //Manipular a exception
                // Injetar alguma LIB de tratamento
                // Gravar log
                // Email para admin
                // Retornar cod. erro amigável
                // SEMPRE USE ASYNC AQUI
                filterContext.ExceptionHandled = true;//avisa o IIS para deixar disponível a memória para aplicação
                filterContext.Result = new HttpStatusCodeResult(500);

            }

            base.OnActionExecuted(filterContext);
        }
    }
}
