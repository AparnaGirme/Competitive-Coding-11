public class Solution {
    // TC => O(n)
    // SC => O(n)
    public string RemoveKdigits(string num, int k) {
        if(num == null || num.Length == 0 || k ==0){
            return num;
        }
        Stack<int> stack = new Stack<int>();
        stack.Push((int)(num[0] - '0'));
        for(int i = 1; i< num.Length; i++){
            var number = (int)(num[i] - '0');
            if(stack.Count >0 && stack.Peek() < number){
                stack.Push(number);
                continue;
            }
            while(stack.Count >0 && stack.Peek() > number && k > 0){
                stack.Pop();
                k--;
                if(k == 0){
                    break;
                }
            }
            stack.Push(number);
        }
        for(int  i = 0; i< k; i++){
            stack.Pop();
        }
        StringBuilder sb = new StringBuilder();
        //to avoid leading zeros
        Stack<int> noLeadingZeroes = new Stack<int>();
        while(stack.Count > 0){
                noLeadingZeroes.Push(stack.Pop());
        }
        while(noLeadingZeroes.Count > 0 && noLeadingZeroes.Peek() == 0){
            noLeadingZeroes.Pop();
        }
        while(noLeadingZeroes.Count > 0){
            sb.Append(noLeadingZeroes.Pop());
        }
        
       return sb.Length == 0 ? "0" : sb.ToString();   
    }
}