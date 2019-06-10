#include <string>
#include <vector>
#include <iostream>

using namespace std;

int main()
{
	string str1, str2;
	int n1, n2, m;
	cin >> str1;
	cin >> str2;
	n1 = str1.length()+1;
	n2 = str2.length()+1;
	vector<int> s(n1);	
	for (int i = 0; i < n1; i++) s[i] = i;	
	for (int i = 1; i < n2; i++) 
	{
		for (int j = n1-1; j > 0; j--) 
		{
			m = 1;
			if (str2[i - 1] == str1[j - 1]) m = 0;
			if (s[j] + 1 < s[j - 1] + m) s[j]++;
			else s[j] = s[j - 1] + m;
		}
		s[0] = i;	
		for (int j = 1; j < n1; j++)
			if (s[j - 1] + 1 < s[j]) s[j] = s[j - 1] + 1;
	}
	cout<< s[n1-1] <<endl;
	return 0;
}