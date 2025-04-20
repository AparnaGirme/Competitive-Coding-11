public class Solution {
    // TC => O(n)
    // SC => O(n)

    public int EvalRPN(string[] tokens) {
        if(tokens == null || tokens.Length == 0){
            return 0;
        }

        Stack<int> stack = new Stack<int>();
        int num1 = 0, num2 = 0, tempResult = 0;

        for(int i = 0; i < tokens.Length; i++){
            string token = tokens[i];
            if(Int32.TryParse(token, out int temp)){
                stack.Push(temp);
            }
            else{
                num2 = stack.Pop();
                num1 = stack.Pop();
                switch(token){
                    case "+": 
                        tempResult = num1 + num2;
                        break;
                    case "-":
                        tempResult = num1 - num2;
                        break;
                    case "*":
                        tempResult = num1 * num2;
                        break;
                    case "/":
                        if(num2 == 0){
                            break;
                        }
                        tempResult = num1 / num2;
                        break;
                }
                stack.Push(tempResult);
            }
        }
        return stack.Pop();
    }
}