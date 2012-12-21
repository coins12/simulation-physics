module TEST;
wire [19:0] state;
reg clk,res;
reg [4:0] count;
reg [19:0] init;
integer i;

parameter STEP = 10;

autocell a0 (init, clk, res, state);

initial begin
	$display("=============density is 0.3=============");
	init=20'b00000010100100110001;
	$dumpfile("dump.vcd");
	$dumpvars(0, TEST);
	count = 0;
	res = 1;
	#1 res = 0;
	$monitor ("%t: state=%b", $time, state);
	#1 res = 1;

	repeat (20)
	begin
		clk = 1; #(STEP/2);
		clk = 0; #(STEP/2);
		count = count + 1;
	end

	$display("=============density is 0.5=============");
  #1
	init=20'b10101010101010101010;
	count = 0;
	res = 1;
	#1 res = 0;
	$monitor ("%t: state=%b", $time, state);
	#1 res = 1;

	repeat (20)
	begin
		clk = 0; #(STEP/2);
		clk = 1; #(STEP/2);
		count = count + 1;
	end

	$display("=============density is 0.7=============");
  #1
	init=20'b11111101011011001110;
	count = 0;
	res = 1;
	#1 res = 0;
	$monitor ("%t: state=%b", $time, state);
	#1 res = 1;

	repeat (20)
	begin
		clk = 0; #(STEP/2);
		clk = 1; #(STEP/2);
		count = count + 1;
	end
end
endmodule

