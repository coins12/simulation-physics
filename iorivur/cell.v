module autocell (input [19:0] init, input clk, input res, output reg [19:0] state);

wire [19:0] nextst;

rule rule184 (184, state, nextst);

always@(posedge clk or negedge res)
begin
	if (~res)
	begin
		state <= init;
	end
	else
	begin
		state <= nextst;
	end
end

endmodule

module rule (input [7:0] rul, input [19:0] state, output [19:0] nextst);

function cnst;
	input [7:0] rul;
	input [2:0] ast;
	case (ast)
		3'b111: cnst = rul [7];
		3'b110: cnst = rul [6];
		3'b101: cnst = rul [5];
		3'b100: cnst = rul [4];
		3'b011: cnst = rul [3];
		3'b010: cnst = rul [2];
		3'b001: cnst = rul [1];
		3'b000: cnst = rul [0];
	endcase
endfunction

function [2:0] cut;
	input [4:0] pos;
	input [19:0] state;
	if (pos == 0) begin
		cut = { state[1], state[0], state[19]};
	end
	else if (pos == 19) begin
		cut = { state[0], state[19], state[18]};
	end
	else begin
		cut = { state[pos+1], state[pos], state[pos-1] };
	end
endfunction

assign nextst[ 0] = cnst (rul, cut( 0,state));
assign nextst[ 1] = cnst (rul, cut( 1,state));
assign nextst[ 2] = cnst (rul, cut( 2,state));
assign nextst[ 3] = cnst (rul, cut( 3,state));
assign nextst[ 4] = cnst (rul, cut( 4,state));
assign nextst[ 5] = cnst (rul, cut( 5,state));
assign nextst[ 6] = cnst (rul, cut( 6,state));
assign nextst[ 7] = cnst (rul, cut( 7,state));
assign nextst[ 8] = cnst (rul, cut( 8,state));
assign nextst[ 9] = cnst (rul, cut( 9,state));
assign nextst[10] = cnst (rul, cut(10,state));
assign nextst[11] = cnst (rul, cut(11,state));
assign nextst[12] = cnst (rul, cut(12,state));
assign nextst[13] = cnst (rul, cut(13,state));
assign nextst[14] = cnst (rul, cut(14,state));
assign nextst[15] = cnst (rul, cut(15,state));
assign nextst[16] = cnst (rul, cut(16,state));
assign nextst[17] = cnst (rul, cut(17,state));
assign nextst[18] = cnst (rul, cut(18,state));
assign nextst[19] = cnst (rul, cut(19,state));

endmodule


module TEST;

wire [19:0] state;
reg clk,res;
reg [4:0] count;
wire [19:0] init = 20'habcde;

parameter STEP = 100;

autocell a0 (init, clk, res, state);

initial begin
	count = 0;
	$monitor ("%t: state=%b", $time, state);
	res = 1;
	#1 res = 0;
	#1 res = 1;
end

always begin
	if (count == 20)
	begin
		$finish;
	end
	else
	begin
		clk = 0; #(STEP/2);
		clk = 1; #(STEP/2);
		count = count + 1;
	end
end

endmodule

