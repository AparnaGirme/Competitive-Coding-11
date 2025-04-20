public class Solution {
    // TC => O(nk)
    // SC => O(n)
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets) {
        if(string.IsNullOrEmpty(s) || indices == null || indices.Length == 0){
            return string.Empty;
        }

        int[] newIndices = new int[s.Length];
        Array.Fill(newIndices, -1);
        StringBuilder sb = new StringBuilder();
        

        for(int i = 0; i< indices.Length; i++){ 
            int index = indices[i]; 
            int sourceLength = sources[i].Length; 
            string source = sources[i]; 

            if(index + sourceLength <= s.Length && s.Substring(index, sourceLength) == source){
                newIndices[index] = i;
            }
        }

        int indx = 0;
        while(indx < s.Length){
            if(newIndices[indx] >= 0){
                int newIndex = newIndices[indx];
                sb.Append(targets[newIndex]);
                indx += sources[newIndex].Length;
            }
            else{
                sb.Append(s[indx]);
                indx++;
            }
        }

        return sb.ToString();
    }
}