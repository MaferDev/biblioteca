//*******************************************************
//********Usando DataContractJsonSerializer**************
//*******************************************************

[DataContract] 
class Blog 
{ 
    [DataMember] 
    public string Name { get; set; } 
   [DataMember] 
    public string Description { get; set; } 
} 

//*********************Serialización***************
Blog bsObj = new Blog () 
{ 
    Name = "estradawebgroup", 
    Description = " Compartir conocimiento " 
}; 
DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Blog)); 
MemoryStream msObj = new MemoryStream(); 
js.WriteObject(msObj, bsObj); 
msObj.Position = 0;  
StreamReader sr = new StreamReader(msObj); 
// "{\"Description\":\" Compartir conocimiento \",\"Name\":\"estradawebgroup\"}" 
string json = sr.ReadToEnd();    
sr.Close(); 
msObj.Close(); 


//*********************Deserialización***************

string json = "{\"Description\":\" Compartir conocimiento \",\"Name\":\"estradawebgroup\"}"; 
using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json))) 
{ 
   // Deserialization from JSON 
   DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Blog)); 
   Blog bsObj2 = (Blog)deserializer.ReadObject(ms); 
   Response.Write("Name: " + bsObj2.Name); // Name: estradawebgroup
   Response.Write("Description: " + bsObj2.Description); // Description: Compartir conocimiento 
} 


//*******************************************************
//******************Usando Json.NET**********************
//*******************************************************

// Creating Blog object 
Blog bsObj = new Blog () 
{ 
    Name = "estradawebgroup", 
    Description = "Compartir conocimiento" 
}; 


//*********************Serialización***************

// Convert Blog object to JOSN string format 
string jsonData = JsonConvert.SerializeObject(bsObj); 
Response.Write(jsonData); 

//*********************Deserialización***************

string json = @ "{
'Nombre' : 'estradawebgroup’,
'Descripción' : 'Compartir conocimiento'
} ";
Blog bsObj = JsonConvert.DeserializeObject <Blog> (json);
Response.Write (bsObj.Name);



 //https://www.estradawebgroup.com/Post/Serializacion-y-deserializacion-JSON-con-C-/4232