using ClassMateDesktop.models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMateDesktop
{
    class Connector
    {
        private string baseUrl = "http://localhost:3000/api";
        private RestClient client;

        public Connector()
        {
            client = new RestClient(baseUrl);
        }


        public List<ClassRoom> getClasses(string token)
        {
            var request = new RestRequest("get-class", Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddHeader("Authorization", token);
            IRestResponse<List<ClassRoom>> response = client.Execute<List<ClassRoom>>(request);
            return response.Data;
        }

        public ClassRoom getClass(string token,string _id)
        {
            var request = new RestRequest("/get-single-class/"+_id, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddHeader("Authorization", token);
            IRestResponse<ClassRoom> response = client.Execute<ClassRoom>(request);
            
            return response.Data;
        }

        public List<Lecture> getLectures(string token,string _id)
        {
            var request = new RestRequest("get-lectures/"+_id, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddHeader("Authorization", token);
            IRestResponse<List<Lecture>> response = client.Execute<List<Lecture>>(request);
            return response.Data;
        }

        public void postAnswer(string token,string _question,string details)
        {
            var request = new RestRequest("answer/answer-question" , Method.POST);
            request.RequestFormat = DataFormat.Json;
            
            request.AddHeader("Authorization", token);

            request.AddBody(new { _question = _question, details = details });
           // request.AddBody("_question", _question);
          //  request.AddBody("details", details);
            IRestResponse response = client.Execute(request);
        }


    }
}
