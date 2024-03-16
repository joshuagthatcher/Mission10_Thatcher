import { useEffect, useState } from "react";
import { Bowlers } from "../types/Bowlers";
function BowlerList() {
  const [bowlerData, setBowlerData] = useState<Bowlers[]>([]);
  useEffect(() => {
    const fetchBowlerData = async () => {
      const rsp = await fetch("http://localhost:5231/BowlingLeague");
      const b = await rsp.json();
      setBowlerData(b);
    };
    fetchBowlerData();
  }, []);

  return (
    <>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlerData.map(
            (f) =>
              (f.TeamName === "Marlins" || f.TeamName === "Sharks") && (
                <tr key={f.BowlerID}>
                  <td>
                    {f.BowlerFirstName}{" "}
                    {f.BowlerMiddleInit && ` ${f.BowlerMiddleInit}`}{" "}
                    {/*Checks if the middle initial is blank*/}
                    {f.BowlerLastName}
                  </td>
                  <td>{f.TeamName}</td>
                  <td>{f.BowlerAddress}</td>
                  <td>{f.BowlerCity}</td>
                  <td>{f.BowlerState}</td>
                  <td>{f.BowlerZip}</td>
                  <td>{f.BowlerPhoneNumber}</td>
                </tr>
              ),
          )}
        </tbody>
      </table>
    </>
  );
}
export default BowlerList;
