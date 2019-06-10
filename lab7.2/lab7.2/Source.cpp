#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

int main()
{
	ifstream in;													
	vector<string> str(21);
	vector<vector<int>> m(20,vector<int> (20));
	string str1, str2, hstr = "ACDEFGHIKLMNPQRSTVWY";
	int ind = -5;
	in.open("C:\\Users\\l\\Documents\\Учёба\\биоинф\\PAM250_1.txt");
	for (int i = 0; i < 21; i++) 
		getline(in, str[i]);
	in.close();
	in.open("C:\\Users\\l\\Documents\\Учёба\\биоинф\\dataset_216105_1.txt");
	getline(in, str1);
	getline(in, str2);
	in.close();
	for (int i = 1; i < 21; i++) 
	{
		str[i].erase(0, 1);
		for (int j = 0; j < 20; j++) 
		{
			m[i - 1][j] = stoi(str[i].substr(0, 3));
			str[i].erase(0, 3);
		}
	}
	int n1 = str1.length(), n2 = str2.length();
	vector<vector<int>> res(n1 + 1, vector<int>(3));
	vector<int> temp(3,0);
	vector<int> max(1);
		for (int i = 0; i < n1 + 1; i++)
		res[i][0] = 0;
	for (int i = 1; i < n2 + 1; i++) 
	{
		for (int j = n1; j > 0; j--)
			if (res[j][0] + ind > res[j - 1][0] + m[hstr.find(str2[i - 1])][hstr.find(str1[j - 1])])
			{
				res[j][0] += ind;
				res[j].push_back(2);
			}
			else
			{
				res[j] = res[j - 1];
				res[j][0] += m[hstr.find(str2[i - 1])][hstr.find(str1[j - 1])];
				res[j].push_back(3);
			}
		res[0][0] += ind;
		res[0].push_back(2);
		for (int j = 1; j < n1 + 1; j++) 
		{
			if (res[j - 1][0] + ind > res[j][0])
			{
				res[j] = res[j - 1];
				res[j][0] += ind;
				res[j].push_back(1);
			}
			if (res[j][0] < 0)
				res[j] = temp;
			else
			{
				if (res[j][1] * res[j][2] == 0)
				{
					res[j][1] = i;
					res[j][2] = j;
				}
				if (res[j][0] > max[0])
					max = res[j];
			}
		}
	}
	cout << max[0] << endl;
	string res1 = "", res2 = "";
	int f = max[2]-1, s = max[1]-1;
	for (int i = 3; i < max.size(); i++)
		switch (max[i]) 
	{
		case 1:res2 += '-'; res1 += str1[f]; f++; break;
		case 2:res1 += '-'; res2 += str2[s]; s++; break;
		case 3:res1 += str1[f]; f++; res2 += str2[s]; s++; break;
		}
	std::ofstream out("C:\\Users\\l\\Documents\\Учёба\\биоинф\\f.txt", std::ios::app);
	if (out.is_open())
	{
		out << res1 << endl;
		out << res2 << endl;
	}
	out.close(); 
	return 0;
}