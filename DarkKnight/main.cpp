#include <cstdio>
#include <iostream>
#include <unordered_map>
#include <queue>


#define string std::string
#define cout std::cout
#define adjacency_list std::unordered_map<T, int>




template<typename T>
class Graph
{

  private:

    std::unordered_map<T, adjacency_list> vertices;

  public:

   void add_edge(T node1, T node2, int weight = 1)
   {

     if(vertices.find(node1) == vertices.end())
       vertices[node1] = adjacency_list();


     if(vertices.find(node2) == vertices.end())
       vertices[node2] = adjacency_list();



     vertices[node1][node2] = weight;
     vertices[node2][node1] = weight;

   }

// -------------------------------->>BFS<<-------------------------------//

   std::unordered_map<T, string> colors;
   std::unordered_map<T, int> distance;
   std::unordered_map<T, T*> parent;
   std::queue<T>Q;
   
   
   void initialize()
   {
     for(auto &vertex : vertices)
     {
       colors[vertex.first] = "white";
       distance[vertex.first] = -1; 
       parent[vertex.first] = nullptr;
      
     }

     T s = vertices.begin()->first;
     Q.push(s);
     colors[s] = "grey";
     distance[s] = 0;

   }

   void discover()
   {

   }


   void bfs()
   {
     initialize();
     

   }





// ----------------------------------------------------------------------//

   void print_all()
   {

      for(auto &var1 : vertices)
      {
        cout << "VARTES [ " << var1.first << " ]" <<  " ---> [ ";

        for(auto &var2 : var1.second)
        {
          cout << var2.first << ", ";
        }

        printf("]\n");

      }

   }


};

int main (int argc, char *argv[])
{

  Graph<string> g;
  g.add_edge("ahmed", "ali");
  g.add_edge("ahmed", "karim");
  g.add_edge("ali", "Nour");
  g.add_edge("karim", "Nour");

  g.bfs();

  g.print_all();




  return 0;
}
